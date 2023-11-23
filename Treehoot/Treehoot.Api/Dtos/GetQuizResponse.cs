using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetQuizResponse : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
