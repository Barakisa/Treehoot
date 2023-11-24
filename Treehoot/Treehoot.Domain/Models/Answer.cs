namespace Treehoot.Domain.Models;

public class Answer : IEntity, IGetable
{
    public Answer(int id, bool isCorrect, string text)
    {
        Id = id;
        IsCorrect = isCorrect;
        Text = text;
    }

    public int Id { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }

    //relationships
    public Question Question { get; set; }
}
