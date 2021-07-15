using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop.Models
{
    public class CoffeedbContext:DbContext
    {
        public DbSet<Product> TblProducts { get; set; }
        public DbSet<Sale> TblSales { get; set; }
        public DbSet<Pay> TblPays { get; set; }
        public string Con= @"Data Source= localhost;Initial Catalog=CoffeeShopDb; User ID=sa;Password=Rootkg12%";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Con);
        }
    }
}