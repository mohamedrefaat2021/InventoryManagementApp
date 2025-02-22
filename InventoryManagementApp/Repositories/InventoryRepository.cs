using InventoryManagementApp.Database;
using InventoryManagementApp.Interface;
using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryItem>> GetAllItemsAsync()
    {
        return await _context.InventoryItems.ToListAsync();
    }

    public async Task AddItemAsync(InventoryItem item)
    {
        _context.InventoryItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(InventoryItem item)
    {
        _context.InventoryItems.Update(item);
        await _context.SaveChangesAsync();
    }

   
}
