namespace Treehoot_API.Models;

public class Quiz
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Timer { get; set; }

    public Stage? Stages { get; set; }
}