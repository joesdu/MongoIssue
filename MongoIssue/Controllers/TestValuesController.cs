using Microsoft.AspNetCore.Mvc;

namespace MongoIssue.Controllers;

[Route("api/[controller]/[action]"), ApiController]
public class TestValuesController : ControllerBase
{
    private readonly DbContext _db;

    public TestValuesController(DbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task Insert()
    {
        var obj = new
        {
            Date = DateTime.Now,
            Text = "test"
        };
        await _db.TestValues.InsertOneAsync(obj);
    }
}