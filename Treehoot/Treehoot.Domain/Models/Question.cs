namespace Treehoot.Domain.Models;

public class Question : IEntity, IGetable
{
    public Question(int id, string topic, string questionText)
    {
        Id = id;
        Topic = topic;
        QuestionText = questionText;
    }

    public int Id { get; set; }
    public string Topic {  get; set; }
    public string QuestionText{ get; set; }

    //realtionships
    public List<Answer> Answers { get; set; }
    public Stage Stage { get; set; }

}
