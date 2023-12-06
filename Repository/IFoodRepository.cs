using System.Collections.Generic;
using System.Threading.Tasks;
using FoodStore.Models;

namespace FoodStore.Repository
{
    public interface IFoodStoreRepository
    {
        Task<List<OptionDetailsDto>> GetAllOptions();
        Task<OptionDetailsDto> GetOptionById(int id);
        Task<int> CreateOption(CreateOptionDto model);
        Task<bool> UpdateOption(int id, UpdateOptionDto model);
        Task<bool> RemoveOption(int id);

    }
}