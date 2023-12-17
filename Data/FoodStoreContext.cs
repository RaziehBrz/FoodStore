using Microsoft.EntityFrameworkCore;

namespace FoodStore.Data
{
    public class FoodStoreContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(a => a.OrdersDetails)
            .WithOne(b => b.Order)
            .HasForeignKey(b => b.OrderId);

            modelBuilder.Entity<User>()
            .HasMany(a => a.Orders)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
            .HasMany(a => a.payments)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Order>()
          .HasOne(p => p.Payment) //Order has one Payment
          .WithOne(p => p.Order) //Payment is associated with one Order
          .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Discount>()
             .HasMany(a => a.payments)
             .WithOne(b => b.Discount)
             .HasForeignKey(b => b.DiscountId);

            modelBuilder.Entity<Item>()
            .HasMany(a => a.orderDetails)
            .WithOne(b => b.Item)
            .HasForeignKey(b => b.OptionId);


        }


        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public FoodStoreContext(DbContextOptions<FoodStoreContext> options) : base(options)
        {
        }
    }
}