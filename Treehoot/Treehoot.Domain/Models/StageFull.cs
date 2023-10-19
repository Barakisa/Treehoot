namespace Treehoot.Domain.Models;

public struct StageFull
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<QuestionFull> Questions { get; set; }
}