namespace FoodStore.Data
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }
        public int OrderId { get; set; }
        public string CardNumber { get; set; }
        public int Discount_Price { get; set; }
        public int Total_Amount { get; set; }
        public int Total_Price { get; set; }
        public bool Status { get; set; } //True = successful / False = Unsusccessful
        public User User { get; set; }
        public Order Order { get; set; }
        public Discount Discount { get; set; }

    }
}