namespace Treehoot.Domain.Models;

public class Stage
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<Question> Questions { get; set; }
}

