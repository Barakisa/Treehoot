using System.Security.Cryptography.X509Certificates;

namespace Treehoot_API.Models;

public class Question
{
    public long Id { get; set; }
    public string ? QuestionSentence{ get; set; }
    public  Answer? Answers { get; set; }
}
