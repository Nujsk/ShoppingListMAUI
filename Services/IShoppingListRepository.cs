using UpggiftMAUI.Models;

namespace UpggiftMAUI.Services
{
    public interface IShoppingListRepository
    {
        Task<List<ShoppingList>> GetAllAsync();
        Task<int> AddAsync(ShoppingList item);
        Task<int> UpdateAsync(ShoppingList item);
        Task<int> DeleteAsync(ShoppingList item);
        Task<ShoppingList> GetListByIdAsync(Guid listId);
    }
}
