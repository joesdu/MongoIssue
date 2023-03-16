using EasilyNET.Mongo;
using MongoDB.Driver;

// ReSharper disable ClassNeverInstantiated.Global

namespace MongoIssue;

public sealed class DbContext : EasilyNETMongoContext
{
    public IMongoCollection<dynamic> TestValues => Database.GetCollection<dynamic>("values");
}