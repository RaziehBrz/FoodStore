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
            var typeList = _context.optionsTypes.Select(x => x.Id);
            var categoryList = _context.Categories.Select(x => x.Id);
            if (typeList.Contains(model.TypeId) && categoryList.Contains(model.CategoryId))
            {
                var id = await _foodStoreRepository.CreateOption(model);
                return Ok(id);
            }
            return BadRequest("You entered valid values!");
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
        //Get all categories
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _foodStoreRepository.GetAllCategories();
            return Ok(categories);
        }
        //Get a category by Id
        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _foodStoreRepository.GetCategoryById(id);
            if (category is null) return BadRequest("There is no category with this id!");
            return Ok(category);
        }
        //Add a new category
        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto model)
        {
            var category = await _foodStoreRepository.CreateCategory(model);
            return Ok(category);
        }
        //Update a category by id
        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategoryById(int id, UpdateCategoryDto model)
        {
            var result = await _foodStoreRepository.UpdateCategoryById(id, model);
            if (result) return Ok(result);
            return BadRequest("There is no category with this id!");
        }
        //Delete a category by id
        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> RemoveCategoryById(int id)
        {
            var result = await _foodStoreRepository.RemoveCategoryById(id);
            if (result) return Ok(result);
            return BadRequest("There is no category with this id!");
        }

    }
}