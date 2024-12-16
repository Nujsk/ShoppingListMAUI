using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpggiftMAUI.Models;

namespace UpggiftMAUI.Services
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly SQLite.SQLiteAsyncConnection _connection;

        public ShoppingItemRepository(DatabaseService databaseService)
        {
            _connection = databaseService.Connection;
        }

        public async Task<int> AddAsync(ShoppingItem item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<int> DeleteAsync(ShoppingItem item)
        {
            return await _connection.DeleteAsync(item);
        }

        public async Task<List<ShoppingItem>> GetAllAsync()
        {
            return await _connection.Table<ShoppingItem>().ToListAsync();
        }

        public async Task<List<ShoppingItem>> GetByListIdAsync(Guid listId)
        {
            return await _connection.Table<ShoppingItem>().Where(i => i.ListId == listId).ToListAsync();
        }

        public async Task<int> UpdateAsync(ShoppingItem item)
        {
            return await _connection.UpdateAsync(item);
        }
    }
}
