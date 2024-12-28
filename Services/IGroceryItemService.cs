using Kuprynas.Models;

namespace Kuprynas.Services
{
    public interface IGroceryItemService
    {
        Task<IEnumerable<GroceryItem>> GetAllItemsAsync();
        Task<GroceryItem> GetItemByIdAsync(int id);
        Task AddItemAsync(GroceryItem groceryItem);
        Task UpdateItemAsync(GroceryItem groceryItem);
        Task DeleteItemAsync(int id);
    }
}
