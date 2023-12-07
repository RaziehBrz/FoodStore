using Microsoft.EntityFrameworkCore;

namespace FoodStore.Data
{
    public class FoodStoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OptionsType> optionsTypes { get; set; }
        public FoodStoreContext(DbContextOptions<FoodStoreContext> options) : base(options)
        {
        }
    }
}