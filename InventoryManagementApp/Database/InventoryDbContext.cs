using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApp.Database
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }

        // ✅ Add a constructor that accepts DbContextOptions
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Prevent overriding options when provided
            {
                optionsBuilder.UseSqlite("Data Source=inventory.db");
            }
        }
    }
}
