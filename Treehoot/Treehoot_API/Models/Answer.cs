namespace Treehoot_API.Models;

public class Answer
{
    public Guid Id { get; set; }

    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
