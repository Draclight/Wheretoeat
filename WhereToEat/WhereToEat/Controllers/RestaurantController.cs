using Microsoft.AspNetCore.Mvc;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Models;

namespace WhereToEat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {

        }
    }
}