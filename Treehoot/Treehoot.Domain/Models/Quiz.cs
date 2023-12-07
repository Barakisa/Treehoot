namespace Treehoot.Domain.Models;

public class Quiz : IEntity, IGetable
{
    public Quiz(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }

    //relationships
    public List<Stage> Stages { get; set; }
}