using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagementApp.Database;
using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class InventoryRepositoryTests
{
    private InventoryDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase(databaseName: "InventoryTestDb")
            .Options;

        return new InventoryDbContext(options);
    }


    [Fact]
    public async Task GetAllItemsAsync_ShouldReturnAllItems()
    {
        // Arrange
        var context = GetDatabaseContext();
        context.InventoryItems.AddRange(new List<InventoryItem>
        {
            new InventoryItem { Id = 1, Name = "Item1", Category = "Category1", StockQuantity = 10 },
            new InventoryItem { Id = 2, Name = "Item2", Category = "Category2", StockQuantity = 20 }
        });
        await context.SaveChangesAsync();

        var repository = new InventoryRepository(context);

        // Act
        var items = await repository.GetAllItemsAsync();

        // Assert
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public async Task AddItemAsync_ShouldAddNewItem()
    {
        // Arrange
        var context = GetDatabaseContext();
        var repository = new InventoryRepository(context);
        var newItem = new InventoryItem { Id = 3, Name = "Item3", Category = "Category3", StockQuantity = 15 };

        // Act
        await repository.AddItemAsync(newItem);
        var items = await repository.GetAllItemsAsync();

        // Assert
        Assert.Single(items);
        Assert.Equal("Item3", items[0].Name);
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldUpdateExistingItem()
    {
        // Arrange
        var context = GetDatabaseContext();
        var repository = new InventoryRepository(context);
        var item = new InventoryItem { Id = 4, Name = "OldItem", Category = "OldCategory", StockQuantity = 5 };
        context.InventoryItems.Add(item);
        await context.SaveChangesAsync();

        // Act
        item.Name = "UpdatedItem";
        await repository.UpdateItemAsync(item);
        var updatedItem = await context.InventoryItems.FindAsync(4);

        // Assert
        Assert.Equal("UpdatedItem", updatedItem.Name);
    }

   
}
