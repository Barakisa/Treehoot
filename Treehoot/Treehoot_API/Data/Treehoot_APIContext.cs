using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Treehoot.Domain.Models;

namespace Treehoot_API.Data
{
    public class Treehoot_APIContext : DbContext
    {
        public Treehoot_APIContext (DbContextOptions<Treehoot_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Treehoot.Domain.Models.Answer> Answer { get; set; } = default!;
    }
}
