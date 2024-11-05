using Project.Lab4.API2.Domain.Catalog; 
using Microsoft.EntityFrameworkCore;

namespace Project.Lab4.API2.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
