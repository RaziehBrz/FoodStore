using System.Collections.Generic;

namespace FoodStore.Data
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Total_Order_Price { get; set; }
        public int Shipping_Cost { get; set; }
        public int Status_Id { get; set; }
        public ICollection<OrderDetails> OrdersDetails { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
    }
}