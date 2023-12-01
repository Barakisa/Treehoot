using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Data
{
    public class TreehootApiContext : DbContext
    {
        public TreehootApiContext (DbContextOptions<TreehootApiContext> options)
            : base(options)
        {
        }

        public DbSet<Treehoot.Domain.Models.Answer> Answer { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Question> Question { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Stage> Stage { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Quiz> Quiz { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.User> User { get; set; } = default!;

    }
}
