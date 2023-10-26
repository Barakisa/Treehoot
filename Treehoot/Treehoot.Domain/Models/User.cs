using System.ComponentModel.DataAnnotations;

namespace Treehoot.Domain.Models;
public record User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

}

