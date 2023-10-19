namespace Treehoot.Domain.Models;

public struct QuestionFull
{
    public int Id { get; set; }
    
    public string QuestionText{ get; set; }
    public List<Answer> Answers { get; set; }
}
