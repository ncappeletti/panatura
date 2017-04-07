using Microsoft.EntityFrameworkCore;
using panatura.Model.Entities;
using panatura.Model.MapEntities;

namespace panatura.Model
{
    public class PanaturaContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PanaturaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapProducts();
        }
    }
}