namespace Treehoot.Domain.Models;

public class ApiCallResult
{
    public Guid Id { get; set; }
    public String DateTime { get; set; }
    public bool IsSuccessful { get; set; }
    public int ItemCount { get; set; }
}

