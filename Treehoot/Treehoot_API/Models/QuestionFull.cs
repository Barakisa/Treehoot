namespace Treehoot_API.Models;

public class QuestionFull
{
    public int Id { get; set; }
    
    public string QuestionText{ get; set; }
    public List<Answer> Answers { get; set; }
}
