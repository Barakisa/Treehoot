using System.Security.Cryptography.X509Certificates;

namespace Treehoot_API.Models;

public class Question
{
    public int Id { get; set; }
    
    public string QuestionText{ get; set; }
    public List<Answer> Answers { get; set; }
}
