﻿namespace Treehoot_API.Models;

public class StageFull
{
    public int Id { get; set; }

    public string Name { get; set; }
    public List<QuestionFull> Questions { get; set; }
}

