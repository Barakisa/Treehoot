namespace Treehoot.Domain.Models;

public class QuestionFull : IEntity
{
    public int Id { get; set; }
    
    public string QuestionText{ get; set; }
    public List<Answer> Answers { get; set; }

    public QuestionType QuestionType { get; set; }
}
