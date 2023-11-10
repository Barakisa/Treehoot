using System.Globalization;

namespace Treehoot.Domain.Models;

public class Question : IEntity
{
    public Question(int id, int stageId, string topic, string questionText)
    {
        Id = id;
        StageId = stageId;
        Topic = topic;
        QuestionText = questionText;
    }

    public int Id { get; set; }
    
    public int StageId {  get; set; }

    public string Topic {  get; set; }
    public string QuestionText{ get; set; }
    //public List<int> Answers { get; set; }

    //public QuestionType QuestionType { get; set; }
}
