﻿using System.ComponentModel.DataAnnotations;

namespace Treehoot_API.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

}
