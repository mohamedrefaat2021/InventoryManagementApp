using InventoryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Interface
{
    public interface IInventoryRepository
    {
      
            Task<List<InventoryItem>> GetAllItemsAsync();
            Task AddItemAsync(InventoryItem item);
            Task UpdateItemAsync(InventoryItem item);
          
     
    }
}
