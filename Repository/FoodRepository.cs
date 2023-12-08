using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodStore.Data;
using FoodStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodStore.Repository
{
    public class FoodRepository : IFoodStoreRepository
    {
        private readonly FoodStoreContext _context;
        public FoodRepository(FoodStoreContext context)
        {
            _context = context;
        }

        //Get all menu options
        public async Task<List<OptionDetailsDto>> GetAllOptions()
        {
            var options = await _context.MenuOptions.Select(x =>
            new OptionDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).ToListAsync();
            return options;
        }
        //Get a menu option by Id
        public async Task<OptionDetailsDto> GetOptionById(int id)
        {
            var option = await _context.MenuOptions.Where(x => x.Id == id).Select(x =>
            new OptionDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).FirstOrDefaultAsync();
            return option;
        }
        //Get menu options by category
        public async Task<List<OptionDetailsDto>> GetOptionsByCategory(int categoryId)
        {
            var options = await _context.MenuOptions.Where(x => x.CategoryId == categoryId).Select(
                x => new OptionDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    CategoryId = categoryId,
                    TypeId = x.TypeId
                }
            ).ToListAsync();
            return options;
        }
        //Get menu options by type
        public async Task<List<OptionDetailsDto>> GetOptionsByType(int typeId)
        {
            var options = await _context.MenuOptions.Where(x => x.TypeId == typeId).Select(
                x => new OptionDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    TypeId = x.TypeId
                }
            ).ToListAsync();
            return options;
        }
        //Add a new menu option to MenuOptions table
        public async Task<int> CreateOption(CreateOptionDto model)
        {
            var option = new MenuOption()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
                TypeId = model.TypeId
            };
            _context.Add(option);
            await _context.SaveChangesAsync();
            return option.Id;
        }
        //Update a menu option 
        public async Task<bool> UpdateOption(int id, UpdateOptionDto model)
        {
            var option = await _context.MenuOptions.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (option is null) return false;

            option.Name = model.Name;
            option.Price = model.Price;
            option.Description = model.Description;
            option.CategoryId = model.CategoryId;
            option.TypeId = model.TypeId;

            await _context.SaveChangesAsync();
            return true;
        }
        //Delete a menu option
        public async Task<bool> RemoveOption(int id)
        {
            var option = await _context.MenuOptions.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (option is null) return false;

            _context.Remove(option);
            await _context.SaveChangesAsync();
            return true;
        }
        //Get all categories
        public async Task<List<CategoryDetailsDto>> GetAllCategories()
        {
            var categories = await _context.Categories.Select(x =>
            new CategoryDetailsDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return categories;
        }
        //Get a category by id
        public async Task<CategoryDetailsDto> GetCategoryById(int id)
        {
            var category = await _context.Categories.Where(x => x.Id == id).Select
            (x => new CategoryDetailsDto()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return category;
        }
        //Add a new category
        public async Task<int> CreateCategory(CreateCategoryDto model)
        {
            var category = new Category()
            {
                Name = model.Name
            };
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }
        //Update a category by id
        public async Task<bool> UpdateCategoryById(int id, UpdateCategoryDto model)
        {
            var category = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (category is null) return false;

            category.Name = model.Name;
            await _context.SaveChangesAsync();
            return true;
        }
        //Delete a category by Id
        public async Task<bool> RemoveCategoryById(int id)
        {
            var category = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (category is null) return false;

            _context.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}