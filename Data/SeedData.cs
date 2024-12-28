using Kuprynas.Models;

namespace Kuprynas.Data
{
    public static class SeedData
    {
        public static void Initialize(KuprynasDbContext dbContext)
        {
            // Ensure the database is created. If you are using Migrations, 
            // you might prefer `dbContext.Database.Migrate();`
            dbContext.Database.EnsureCreated();

            // If no items exist, seed some sample data
            if (!dbContext.Items.Any())
            {
                var items = new List<GroceryItem>
                {
                    new GroceryItem
                    {
                        Name = "Bananas",
                        Category = "Fruits",
                        Quantity = 6,
                        Unit = "pieces",
                        Price = 3.25m,
                        Purchased = false
                    },
                    new GroceryItem
                    {
                        Name = "Bread",
                        Category = "Bakery",
                        Quantity = 1,
                        Unit = "loaf",
                        Price = 2.99m,
                        Purchased = false
                    }
                };

                dbContext.Items.AddRange(items);
                dbContext.SaveChanges();
            }
        }
    }
}
