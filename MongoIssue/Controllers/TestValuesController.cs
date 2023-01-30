using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoIssue.Extensions;
using MongoIssue.Models;

namespace MongoIssue.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TestValuesController : ControllerBase
{
    private readonly DbContext _db;
    public TestValuesController(DbContext db)
    {
        _db = db;
    }

    private readonly FilterDefinitionBuilder<TestValues> _bf = Builders<TestValues>.Filter;

    [HttpPost]
    public async Task Insert()
    {
        var objs = new List<TestValues>();
        foreach (var i in ..10)
        {
            objs.Add(new()
            {
                Name = $"index:{i}",
                Description = $"des:{i}"
            });
        }

        await _db.TestValues.InsertManyAsync(objs);
    }

    [HttpGet]
    public async Task<List<Tuple<string, string>>> Get()
    {
        var objs = await _db.TestValues.Find(_bf.Empty).Project(c => c.Reference()).ToListAsync();
        return objs;
    }
}
