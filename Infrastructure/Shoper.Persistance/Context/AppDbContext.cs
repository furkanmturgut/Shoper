using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;

namespace Shoper.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=TRKVZ11;Database=Shoper;Trusted_Connection=True;Trust Server Certificate=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
