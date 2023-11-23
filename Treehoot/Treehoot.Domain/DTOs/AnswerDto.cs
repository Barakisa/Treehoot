using Treehoot.Domain.Models;

namespace Treehoot.Domain.DTOs;

public class AnswerDto : IEntity
{
    public int Id { get; set; }

    public int QuestionId {  get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
