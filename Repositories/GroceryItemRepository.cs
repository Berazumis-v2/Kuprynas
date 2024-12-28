using Kuprynas.Data;
using Kuprynas.Models;
using Microsoft.EntityFrameworkCore;

namespace Kuprynas.Repositories
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly KuprynasDbContext _dbContext;

        public GroceryItemRepository(KuprynasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GroceryItem>> GetAllAsync()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<GroceryItem> GetByIdAsync(int id)
        {
            return await _dbContext.Items.FindAsync(id);
        }

        public async Task AddAsync(GroceryItem groceryItem)
        {
            _dbContext.Items.Add(groceryItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GroceryItem groceryItem)
        {
            _dbContext.Items.Update(groceryItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingItem = await _dbContext.Items.FindAsync(id);
            if (existingItem != null)
            {
                _dbContext.Items.Remove(existingItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
