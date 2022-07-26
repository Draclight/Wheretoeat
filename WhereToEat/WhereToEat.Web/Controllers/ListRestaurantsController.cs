using Microsoft.AspNetCore.Mvc;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ListRestaurantsController : ControllerBase
{
    private readonly ILogger<ListRestaurantsController> _logger;
    private readonly IRestaurantService _restaurantService;

    public ListRestaurantsController(ILogger<ListRestaurantsController> logger, IRestaurantService restaurantService)
    {
        _logger = logger;
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public IEnumerable<RestaurantViewModel> Get()
    {
        return _restaurantService.GetAll();
    }
}
