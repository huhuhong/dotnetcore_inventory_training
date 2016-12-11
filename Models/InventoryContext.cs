using inventory_api.Models;
using Microsoft.EntityFrameworkCore;

namespace inventory_api
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }

}