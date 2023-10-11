namespace Treehoot.Domain.Models;

public class Question
{
    public int Id { get; set; }
    
    public string QuestionText{ get; set; }
    public List<int> Answers { get; set; }
}
