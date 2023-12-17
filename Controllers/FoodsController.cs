using System;
using System.Linq;
using System.Threading.Tasks;
using FoodStore.Data;
using FoodStore.Models;
using FoodStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Type = System.Type;


namespace FoodStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly ILogger<FoodsController> _logger;
        private readonly FoodStoreContext _context;
        private readonly IFoodStoreRepository _foodStoreRepository;
        public FoodsController(ILogger<FoodsController> logger,
        IFoodStoreRepository foodStoreRepository,
        FoodStoreContext context)
        {
            _logger = logger;
            _foodStoreRepository = foodStoreRepository;
            _context = context;
        }
        [HttpGet]
        //Get all Items
        public async Task<IActionResult> GetAllItems()
        {
            var Items = await _foodStoreRepository.GetAllItems();
            return Ok(Items);
        }
        [HttpGet("{id}")]
        //Get an Item by id
        public async Task<IActionResult> GetItemById(int id)
        {
            var Item = await _foodStoreRepository.GetItemById(id);
            if (Item is null) return BadRequest("There is no Item with this id!");
            return Ok(Item);
        }
        [HttpGet("categories/{CategoryId}")]
        //Get an Item by category id
        public async Task<IActionResult> GetItemByCategoryId(int categoryid)
        {
            var Items = await _foodStoreRepository.GetItemsByCategoryId(categoryid);
            if (Items.Count == 0) return BadRequest("There is no Item with this category id!");
            return Ok(Items);
        }
        [HttpGet("types/{TypeId}")]
        //Get an Item by item id
        public async Task<IActionResult> GetItemByTypeId(int typeId)
        {
            var Items = await _foodStoreRepository.GetItemsByTypeId(typeId);
            if (Items.Count == 0) return BadRequest("There is no Item with this type id!");
            return Ok(Items);
        }
        //Add a new item
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto model)
        {
            var id = await _foodStoreRepository.CreateItem(model);
            return Ok(id);
        }



    }
}