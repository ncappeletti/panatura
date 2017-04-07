using Microsoft.EntityFrameworkCore;
using panatura.Model.Entities;

namespace panatura.Model.MapEntities
{
    public static class ProductMap
    {
        public static void MapProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().Property(e => e.Code).IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.Name).IsRequired();
        }
    }
}