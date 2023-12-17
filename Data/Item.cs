using System.Collections.Generic;

namespace FoodStore.Data
{
    public class Item : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }
    }
}