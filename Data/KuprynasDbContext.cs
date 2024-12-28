using Kuprynas.Models;
using Microsoft.EntityFrameworkCore;

namespace Kuprynas.Data
{
    public class KuprynasDbContext : DbContext
    {
        private readonly IConfiguration _configugation;
        public DbSet<GroceryItem> Items { get; set; }

        public KuprynasDbContext(IConfiguration configuration)
        {
            _configugation = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configugation.GetConnectionString("PostgreSQL"));
        }
    }
}
