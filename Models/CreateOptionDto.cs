namespace FoodStore.Models
{
    public class CreateOptionDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
    }
}