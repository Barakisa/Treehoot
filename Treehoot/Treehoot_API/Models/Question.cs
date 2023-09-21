using System.Security.Cryptography.X509Certificates;

namespace Treehoot_API.Models;

public class Question
{
    public Question(int id, string questionText, List<Answer> answers)
    {
        Id = id;
        QuestionText = questionText;
        Answers = answers;
    }

    public int Id { get; set; }
    public string QuestionText{ get; set; }
    public List<Answer> Answers { get; set; }
}
