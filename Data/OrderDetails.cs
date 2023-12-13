using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace FoodStore.Data
{
    public class OrderDetails : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int OptionId { get; set; }
        public int Option_Price { get; set; }
        public int Quantity { get; set; }
        public int Total_Price { get; set; }
        public Order Order { get; set; }
    }
}