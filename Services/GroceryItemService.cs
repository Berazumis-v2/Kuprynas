using Kuprynas.Models;
using Kuprynas.Repositories;

namespace Kuprynas.Services
{
    public class GroceryItemService : IGroceryItemService
    {
        private readonly IGroceryItemRepository _groceryItemRepository;

        public GroceryItemService(IGroceryItemRepository groceryItemRepository)
        {
            _groceryItemRepository = groceryItemRepository;
        }

        public async Task<IEnumerable<GroceryItem>> GetAllItemsAsync()
        {
            return await _groceryItemRepository.GetAllAsync();
        }

        public async Task<GroceryItem> GetItemByIdAsync(int id)
        {
            return await _groceryItemRepository.GetByIdAsync(id);
        }

        public async Task AddItemAsync(GroceryItem groceryItem)
        {
            await _groceryItemRepository.AddAsync(groceryItem);
        }

        public async Task UpdateItemAsync(GroceryItem groceryItem)
        {
            await _groceryItemRepository.UpdateAsync(groceryItem);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _groceryItemRepository.DeleteAsync(id);
        }
    }
}
