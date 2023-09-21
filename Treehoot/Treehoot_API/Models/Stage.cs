namespace Treehoot_API.Models;

public class Stage
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public Question[] Questions { get; set; }
}

