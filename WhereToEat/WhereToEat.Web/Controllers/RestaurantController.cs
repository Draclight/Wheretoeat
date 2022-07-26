using Microsoft.AspNetCore.Mvc;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Web.Controllers;

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

    [HttpGet]
    public RestaurantViewModel Get()
    {
        return _restaurantService.SelectR();
    }

    [HttpPost]
    [Route("New")]
    public string New(string _s)
    {
        return $"hello {_s}"; 
    }
}
