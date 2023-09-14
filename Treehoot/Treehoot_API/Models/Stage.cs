namespace Treehoot_API.Models;

public class Stage
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Question[] Questions { get; set; }
    public Dictionary<String, Boolean>? Answers { get; set; }
}

