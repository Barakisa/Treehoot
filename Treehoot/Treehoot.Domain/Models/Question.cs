using Treehoot.Domain.Interfaces;

namespace Treehoot.Domain.Models;

public class Question : IEntity, IGetable
{
    public Question(Guid id, string topic, string questionText)
    {
        Id = id;
        Topic = topic;
        QuestionText = questionText;
    }

    public Guid Id { get; set; }
    public string Topic {  get; set; }
    public string QuestionText{ get; set; }

    //realtionships
    public List<Answer> Answers { get; set; }
    public Stage Stage { get; set; }

}
