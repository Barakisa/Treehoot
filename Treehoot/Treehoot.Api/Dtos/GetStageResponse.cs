using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetStageResponse : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int QuizId { get; set; }
}
