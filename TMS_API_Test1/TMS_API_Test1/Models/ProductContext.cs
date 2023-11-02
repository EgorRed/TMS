using Microsoft.EntityFrameworkCore;

namespace TMS_API_Test1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) 
            : base(options) { }

        public DbSet<ProductItem> ProductItems { get; set; } = null!;
    }
}
