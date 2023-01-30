namespace MongoIssue.Models;

public class TestValues
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Tuple<string, string> Reference() =>
        new Tuple<string, string>(Name, Description);
}