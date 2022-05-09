
using Microsoft.EntityFrameworkCore;
using TaskManagerEntities.Concrete;

namespace TaskManagerDataAccess.Concrete.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=VEDAT;Database=TaskManagerDB;Trusted_Connection=true");
        }

        public DbSet<Gorev> Gorevler { get; set; }
    }
}
