using System;

namespace FoodStore.Data
{
    public class Discount : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discount_Code { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}