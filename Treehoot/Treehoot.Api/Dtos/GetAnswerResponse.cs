using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetAnswerResponse : IEntity
{
    public int Id { get; set; }
    public int QuestionId {  get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
