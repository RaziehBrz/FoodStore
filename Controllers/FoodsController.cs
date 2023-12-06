using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodStore.Controller
{
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly ILogger _logger;
        public FoodsController(ILogger logger)
        {
            _logger = logger;
        }
    }
}