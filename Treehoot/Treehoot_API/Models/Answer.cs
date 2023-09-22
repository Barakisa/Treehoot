namespace Treehoot_API.Models;

public class Answer
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
}
