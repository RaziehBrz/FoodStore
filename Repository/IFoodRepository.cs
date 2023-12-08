using System.Collections.Generic;
using System.Threading.Tasks;
using FoodStore.Models;

namespace FoodStore.Repository
{
    public interface IFoodStoreRepository
    {
        Task<List<OptionDetailsDto>> GetAllOptions();
        Task<OptionDetailsDto> GetOptionById(int id);
        Task<List<OptionDetailsDto>> GetOptionsByCategory(int categoryId);
        Task<List<OptionDetailsDto>> GetOptionsByType(int typeId);
        Task<int> CreateOption(CreateOptionDto model);
        Task<bool> UpdateOption(int id, UpdateOptionDto model);
        Task<bool> RemoveOption(int id);
        Task<List<CategoryDetailsDto>> GetAllCategories();
        Task<CategoryDetailsDto> GetCategoryById(int id);
        Task<int> CreateCategory(CreateCategoryDto model);
        Task<bool> UpdateCategoryById(int id, UpdateCategoryDto model);
        Task<bool> RemoveCategoryById(int id);
    }
}