using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetQuestionResponse : IEntity
{
    public Guid Id { get; set; }
    public Guid StageId { get; set; }
    public string Topic {  get; set; }
    public string QuestionText { get; set; }
}
