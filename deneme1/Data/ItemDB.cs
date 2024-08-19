using deneme1.Models;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Data
{
    public class ItemDB : DbContext
    {
        public ItemDB(DbContextOptions<ItemDB> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
