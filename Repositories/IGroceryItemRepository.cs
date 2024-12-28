using Kuprynas.Models;

namespace Kuprynas.Repositories
{
    public interface IGroceryItemRepository
    {
        Task<IEnumerable<GroceryItem>> GetAllAsync();
        Task<GroceryItem> GetByIdAsync(int id);
        Task AddAsync(GroceryItem groceryItem);
        Task UpdateAsync(GroceryItem groceryItem);
        Task DeleteAsync(int id);
    }
}
