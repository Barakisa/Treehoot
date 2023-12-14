using Treehoot.Domain.Interfaces;

namespace Treehoot.Api.Dtos;

public class GetQuizResponse : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
