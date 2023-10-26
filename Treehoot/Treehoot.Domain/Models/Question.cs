using System.Globalization;

namespace Treehoot.Domain.Models;

public class Question : IEntity
{
    public int Id { get; set; }
    
    public int StageId {  get; set; }

    public string Topic {  get; set; }
    public string QuestionText{ get; set; }
    //public List<int> Answers { get; set; }

    //public QuestionType QuestionType { get; set; }
}
