using CarsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsWebAPI.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
