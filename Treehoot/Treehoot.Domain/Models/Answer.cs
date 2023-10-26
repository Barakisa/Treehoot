namespace Treehoot.Domain.Models;

public class Answer : IEntity
{
    public int Id { get; set; }

    public int QuestionId {  get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
