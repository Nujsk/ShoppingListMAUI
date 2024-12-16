using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpggiftMAUI.Models;

namespace UpggiftMAUI.Services
{
    public interface IShoppingItemRepository
    {
        Task<List<ShoppingItem>> GetAllAsync();
        Task<List<ShoppingItem>> GetByListIdAsync(Guid listId);
        Task<int> AddAsync(ShoppingItem item);
        Task<int> UpdateAsync(ShoppingItem item);
        Task<int> DeleteAsync(ShoppingItem item);
    }
}
