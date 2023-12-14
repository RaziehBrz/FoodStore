using System.Linq;
using System.Threading.Tasks;
using FoodStore.Data;
using FoodStore.Models;
using FoodStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        //Get all options
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _foodStoreRepository.GetAllOptions();
            return Ok(options);
        }
        [HttpGet("{id}")]
        //Get an option by id
        public async Task<IActionResult> GetOptionById(int id)
        {
            var option = await _foodStoreRepository.GetOptionById(id);
            if (option is null) return BadRequest("There is no option with this id!");
            return Ok(option);
        }
        [HttpGet("categories/{CategoryId}")]
        //Get an option by id
        public async Task<IActionResult> GetOptionByCategoryId(int categoryid)
        {
            var options = await _foodStoreRepository.GetOptionsByCategoryId(categoryid);
            if (options.Count == 0) return BadRequest("There is no option with this category id!");
            return Ok(options);
        }
        [HttpGet("types/{TypeId}")]
        //Get an option by id
        public async Task<IActionResult> GetOptionByTypeId(int typeId)
        {
            var options = await _foodStoreRepository.GetOptionsByTypeId(typeId);
            if (options.Count == 0) return BadRequest("There is no option with this type id!");
            return Ok(options);
        }



    }
}