using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetQuestionResponse : IEntity
{
    public int Id { get; set; }
    public string Topic {  get; set; }
    public string QuestionText { get; set; }
    public int StageId { get; set; }
}
