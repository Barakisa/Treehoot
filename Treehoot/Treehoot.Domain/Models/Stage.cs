namespace Treehoot.Domain.Models;

public class Stage : IEntity
{
    public Stage(string name, int id, int quizId)
    {
        Name = name;
        Id = id;
        QuizId = quizId;
    }

    public string Name { get; set; }
    
    public int Id { get; set; }

    public int QuizId { get; set; }
    //public string Name { get; set; }
    //public List<int> Questions { get; set; }
}

