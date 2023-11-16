using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Data
{
    public class TreehootApiContext : DbContext
    {
        public TreehootApiContext (DbContextOptions<TreehootApiContext> options)
            : base(options)
        {
        }

        public DbSet<Treehoot.Domain.Models.Answer> Answer { get; set; } = default!;
    }
}
