namespace FoodStore.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public int TotalPrice { get; set; }
    }
}