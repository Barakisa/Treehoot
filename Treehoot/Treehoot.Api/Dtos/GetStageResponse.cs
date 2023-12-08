using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetStageResponse : IEntity
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string Name { get; set; }
}
