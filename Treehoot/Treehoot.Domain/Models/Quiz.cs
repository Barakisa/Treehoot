﻿namespace Treehoot.Domain.Models;

public class Quiz : IEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Timer { get; set; }
    //public List<int> Stages { get; set; }
}