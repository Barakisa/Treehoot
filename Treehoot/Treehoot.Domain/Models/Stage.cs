﻿namespace Treehoot.Domain.Models;

public class StageFull
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<Question> Questions { get; set; }
}

