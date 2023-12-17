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

        //Get all Items
        public async Task<List<ItemDetailsDto>> GetAllItems()
        {
            var Items = await _context.Items.Select(x =>
            new ItemDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).ToListAsync();
            return Items;
        }
        //Get an Item by id
        public async Task<ItemDetailsDto> GetItemById(int id)
        {
            var Item = await _context.Items.Where(x => x.Id == id).Select(x =>
            new ItemDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).FirstOrDefaultAsync();
            return Item;
        }
        //Get Items by categoryid
        public async Task<List<ItemDetailsDto>> GetItemsByCategoryId(int categoryId)
        {
            var Items = await _context.Items.Where(x => x.CategoryId == categoryId).Select(x =>
            new ItemDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).ToListAsync();
            return Items;
        }
        //Get Items by Typeid
        public async Task<List<ItemDetailsDto>> GetItemsByTypeId(int typeId)
        {
            var Items = await _context.Items.Where(x => x.TypeId == typeId).Select(x =>
            new ItemDetailsDto()
            {

                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                TypeId = x.TypeId
            }).ToListAsync();
            return Items;
        }
        //Add a new item
        public async Task<int> CreateItem(CreateItemDto model)
        {
            var item = new Item()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
                TypeId = model.TypeId,
            };
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
    }
}