using System.Threading.Tasks;
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

        private readonly IFoodStoreRepository _foodStoreRepository;
        public FoodsController(ILogger<FoodsController> logger,
        IFoodStoreRepository foodStoreRepository)
        {
            _logger = logger;
            _foodStoreRepository = foodStoreRepository;
        }
        //Get all menu options
        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _foodStoreRepository.GetAllOptions();
            return Ok(options);
        }
        //Get a menu option by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            var option = await _foodStoreRepository.GetOptionById(id);
            if (option is null) return BadRequest("There is no option with this id!");
            return Ok(option);
        }
        //Add a new menu option to MenuOptions table
        [HttpPost]
        public async Task<IActionResult> CreateOption([FromBody] CreateOptionDto model)
        {
            var id = await _foodStoreRepository.CreateOption(model);
            return Ok(id);
        }
        //Update an menu option by Id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOption(int id, [FromBody] UpdateOptionDto model)
        {
            var result = await _foodStoreRepository.UpdateOption(id, model);
            if (result) return Ok(result);
            return BadRequest("There is no option with this id!");
        }
        //Delete a menu option
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOption(int id)
        {
            var result = await _foodStoreRepository.RemoveOption(id);
            if (result) return Ok(result);
            return BadRequest("There is no option with this id!");
        }
    }
}