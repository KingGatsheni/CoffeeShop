using Coffee_Shop.Configs;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop.Models
{
    public class CoffeedbContext : DbContext
    {
        public DbSet<Product> TblProducts { get; set; }
        public DbSet<Sale> TblSales { get; set; }
        public DbSet<Pay> TblPays { get; set; }
        private readonly DbConfig Con = new DbConfig();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Con._Sqlconnection);
        }
    }
}