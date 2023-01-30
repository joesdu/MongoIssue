using MongoDB.Driver;
using MongoIssue.Models;
// ReSharper disable ClassNeverInstantiated.Global

namespace MongoIssue;

public sealed class DbContext : BaseDbContext
{
    public IMongoCollection<TestValues> TestValues => Database.GetCollection<TestValues>("values");
}