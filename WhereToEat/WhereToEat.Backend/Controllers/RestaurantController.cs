using Microsoft.AspNetCore.Mvc;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Models;

namespace WhereToEat.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpGet("GetAllRestaurants")]
        public IList<RestaurantViewModel> GetAllRestaurants()
        {
            return _restaurantService.GetAll();
        }

        [HttpGet("SelectRestaurant")]
        public RestaurantViewModel SelectRestaurant()
        {
            return _restaurantService.SelectR();
        }
    }
}
