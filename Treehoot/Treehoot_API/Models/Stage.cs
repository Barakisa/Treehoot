namespace Treehoot_API.Models;

public class Stage
{

    public Stage(int id, string name, List<Question> questions)
    {
        Id = id;
        Name = name;
        Questions = questions;
    }

    public int Id { get; set; }

    public string Name { get; set; }
    public List<Question> Questions { get; set; }
}

