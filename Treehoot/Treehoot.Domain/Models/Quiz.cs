namespace Treehoot.Domain.Models;

public class Quiz
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Timer { get; set; }
    public List<Stage> Stages { get; set; }
}