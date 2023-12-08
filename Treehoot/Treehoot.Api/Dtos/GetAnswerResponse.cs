using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetAnswerResponse : IEntity
{
    public Guid Id { get; set; }
    public Guid QuestionId {  get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}
