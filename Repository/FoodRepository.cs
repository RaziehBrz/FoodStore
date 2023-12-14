using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodStore.Data;
using FoodStore.Migrations;
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

        //Get all options
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
        //Get an option by id
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
        //Get options by categoryid
        public async Task<List<OptionDetailsDto>> GetOptionsByCategoryId(int categoryId)
        {
            var options = await _context.MenuOptions.Where(x => x.CategoryId == categoryId).Select(x =>
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
        //Get options by Typeid
        public async Task<List<OptionDetailsDto>> GetOptionsByTypeId(int typeId)
        {
            var options = await _context.MenuOptions.Where(x => x.TypeId == typeId).Select(x =>
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
    }
}