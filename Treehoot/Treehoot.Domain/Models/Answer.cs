using Treehoot.Domain.Interfaces;

namespace Treehoot.Domain.Models;

public class Answer : IEntity, IGetable
{
    public Answer(Guid id, bool isCorrect, string text)
    {
        Id = id;
        IsCorrect = isCorrect;
        Text = text;
    }

    public Guid Id { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }

    //relationships
    public Question Question { get; set; }
}
