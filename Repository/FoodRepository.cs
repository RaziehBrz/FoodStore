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
    }
}