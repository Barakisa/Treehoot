namespace Treehoot.Domain.Models;

public class Quiz : IEntity
{
    public Quiz(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    //public int Timer { get; set; }
    //public List<int> Stages { get; set; }
}