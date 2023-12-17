using System.Collections.Generic;
using System.Threading.Tasks;
using FoodStore.Models;

namespace FoodStore.Repository
{
    public interface IFoodStoreRepository
    {
        Task<List<ItemDetailsDto>> GetAllItems();
        Task<ItemDetailsDto> GetItemById(int id);
        Task<List<ItemDetailsDto>> GetItemsByCategoryId(int categoryId);
        Task<List<ItemDetailsDto>> GetItemsByTypeId(int typeId);
    }
}