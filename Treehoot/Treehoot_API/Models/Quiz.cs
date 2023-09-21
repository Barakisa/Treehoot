namespace Treehoot_API.Models;

public class Quiz
{
    public Quiz(int id, string name, string description, int timer)
    {
        Id = id;
        Name = name;
        Description = description;
        Timer = timer;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Timer { get; set; }

    public List<Stage> Stages { get; set; }
}