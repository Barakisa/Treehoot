namespace Treehoot.Domain.Models;

public class Stage : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<int> Questions { get; set; }
}

