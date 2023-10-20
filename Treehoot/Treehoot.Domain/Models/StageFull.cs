namespace Treehoot.Domain.Models;

public class StageFull : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<QuestionFull> Questions { get; set; }
}