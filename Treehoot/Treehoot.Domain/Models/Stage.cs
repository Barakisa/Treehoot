namespace Treehoot.Domain.Models;

public class Stage : IEntity, IGetable
{
    public Stage(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    //relationships
    public Quiz Quiz { get; set; }
    public List<Question> Questions { get; set; }
}

