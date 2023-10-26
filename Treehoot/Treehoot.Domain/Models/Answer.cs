namespace Treehoot.Domain.Models;

public class Answer : IEntity
{
    public Answer(int id, int questionId, bool isCorrect, string text)
    {
        Id = id;
        QuestionId = questionId;
        IsCorrect = isCorrect;
        Text = text;
    }

    public int Id { get; set; }

    public int QuestionId {  get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
