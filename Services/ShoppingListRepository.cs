using SQLitePCL;
using UpggiftMAUI.Models;

namespace UpggiftMAUI.Services
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly SQLite.SQLiteAsyncConnection _connection;

        public ShoppingListRepository(DatabaseService databaseService)
        {
            _connection = databaseService.Connection;
        }
        public async Task<int> AddAsync(ShoppingList item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<int> DeleteAsync(ShoppingList item)
        {
            return await _connection.DeleteAsync(item);
        }

        public async Task<List<ShoppingList>> GetAllAsync()
        {
            return await _connection.Table<ShoppingList>().ToListAsync();
        }

        public async Task<int> UpdateAsync(ShoppingList item)
        {
            return await _connection.UpdateAsync(item);
        }

        public async Task<ShoppingList> GetListByIdAsync(Guid listId)
        {
            return await _connection.Table<ShoppingList>().Where(i => i.Id == listId).FirstOrDefaultAsync();
        }
    }
}
