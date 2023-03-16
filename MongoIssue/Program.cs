using EasilyNET.Mongo;
using EasilyNET.Mongo.ConsoleDebug;
using EasilyNET.Mongo.Extension;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoIssue;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ×¢²áMongoDB
builder.Services.AddMongoContext<DbContext>(new MongoClientSettings
{
    Servers = new List<MongoServerAddress> { new("192.168.2.17", 27017) },
    Credential = MongoCredential.CreateCredential("admin", "oneblogs", "&oneblogs789")
}, c =>
{
    c.ClusterBuilder = cb => cb.Subscribe(new ActivityEventSubscriber());
    c.LinqProvider = LinqProvider.V3;
}).RegisterEasilyNETSerializer();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger().UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();