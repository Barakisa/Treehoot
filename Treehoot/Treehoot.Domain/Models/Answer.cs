namespace Treehoot.Domain.Models;

public class Answer : IEntity
{
    public Answer() { }
    public Answer(int id, Question question, bool isCorrect, string text)
    {
        Id = id;
        Question = question;
        IsCorrect = isCorrect;
        Text = text;
    }

    public int Id { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }

    //relationships
    public Question Question { get; set; }
}
