using System.Security.Cryptography.X509Certificates;

namespace Treehoot_API.Models;

public class Question
{
    public long Guid { get; set; }
    public string QuestionText{ get; set; }
    public Answer[]? Answers { get; set; }
}
