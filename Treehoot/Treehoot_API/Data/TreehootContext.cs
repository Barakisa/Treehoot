﻿using Microsoft.EntityFrameworkCore;
using Treehoot_API.Models;

namespace Treehoot_API.Data
{
    public class TreehootContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Connection String Here");

        }

    }
}
