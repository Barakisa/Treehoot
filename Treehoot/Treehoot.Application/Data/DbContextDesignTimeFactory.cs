using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treehoot.Application.Data
{
    public class TreehootApiContextFactory : IDesignTimeDbContextFactory<TreehootApiContext>
    {
        public TreehootApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TreehootApiContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Treehoot.Application.Data;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Treehoot.Infrastructure"));

            return new TreehootApiContext(optionsBuilder.Options);
        }
    }
}
