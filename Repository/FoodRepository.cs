using FoodStore.Data;

namespace FoodStore.Repository
{
    public class FoodRepository : IFoodStoreRepository
    {
        private readonly FoodStoreContext _context;
        public FoodRepository(FoodStoreContext context)
        {
            _context = context;
        }


    }
}