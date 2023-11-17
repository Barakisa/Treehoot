using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Treehoot.Domain.Models.Answer> Question { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Answer> Stage { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Answer> Quiz { get; set; } = default!;
        public DbSet<Treehoot.Domain.Models.Answer> User { get; set; } = default!;
    }
}
