using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        private IRestaurantService _restaurantService;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
            _restaurantService = new RestaurantService();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var ret = _restaurantService.SelectR();
            return Json(ret);
        }
    }
}
