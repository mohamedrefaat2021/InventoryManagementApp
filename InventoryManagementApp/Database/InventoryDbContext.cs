using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
            if (!optionsBuilder.IsConfigured)
            {
                // Start from the bin directory and move up to the project root
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName; // Move up 3 levels
                string dbPath = Path.Combine(projectRoot, "inventory.db");

                optionsBuilder.UseSqlite($"Data Source={dbPath}");

                // Debug: Print the database path to verify it's correct
                Console.WriteLine($"Database Path: {dbPath}");
            }
        }
    }
}
