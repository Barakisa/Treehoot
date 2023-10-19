namespace Treehoot.Domain.Models;

public struct QuizFull
{
    public int Id { get; set; }    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Timer { get; set; }
    public List<StageFull> Stages { get; set; }
}