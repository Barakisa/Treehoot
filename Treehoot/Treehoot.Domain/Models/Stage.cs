namespace Treehoot.Domain.Models;

public class Stage : IEntity, IGetable
{
    public Stage(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid  Id { get; set; }
    public string Name { get; set; }
    
    //relationships
    public Quiz Quiz { get; set; }
    public List<Question> Questions { get; set; }
}

