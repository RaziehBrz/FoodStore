using System.Collections.Generic;
using System.Threading.Tasks;
using FoodStore.Models;

namespace FoodStore.Repository
{
    public interface IFoodStoreRepository
    {
        Task<List<OptionDetailsDto>> GetAllOptions();
        Task<OptionDetailsDto> GetOptionById(int id);
        Task<List<OptionDetailsDto>> GetOptionsByCategoryId(int categoryId);
        Task<List<OptionDetailsDto>> GetOptionsByTypeId(int typeId);
    }
}