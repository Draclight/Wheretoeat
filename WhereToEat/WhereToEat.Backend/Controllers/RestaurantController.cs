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
        public RestaurantListViewModel GetAllRestaurants()
        {
            RestaurantListViewModel ret = new RestaurantListViewModel();

            try
            {
                ret = _restaurantService.GetAll();
            }
            catch (Exception ex)
            {
                ret.Error.IsError = true;
                ret.Error.ErrorMessage = ex.Message;
                _logger.LogError(ex.Message);
            }

            return ret;
        }

        [HttpGet("SelectRestaurant")]
        public RestaurantViewModel SelectRestaurant()
        {
            RestaurantViewModel ret = new RestaurantViewModel();
            try
            {
                ret = _restaurantService.SelectR();
            }
            catch (Exception ex)
            {
                ret.Error.IsError = true;
                ret.Error.ErrorMessage = ex.Message;
                _logger.LogError(ex.Message);
            }

            return ret;
        }

        [HttpPut("AddRestaurant")]
        public RestaurantViewModel AddRestaurant(RestaurantViewModel restaurant)
        {
            try
            {
                restaurant = _restaurantService.Add(restaurant);
            }
            catch (Exception ex)
            {
                restaurant.Error.IsError = true;
                restaurant.Error.ErrorMessage = ex.Message;
                _logger.LogError(ex.Message);
            }

            return restaurant;
        }

        [HttpPut("UpdateProba")]
        public bool UpdateProba(RestaurantViewModel rvm)
        {
            bool ret = false;

            try
            {
                ret = _restaurantService.UpdateProba(rvm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return ret;
        }

        [HttpDelete("DeleteRestaurant")]
        public bool Delete(RestaurantViewModel rvm)
        {
            bool ret = false;

            try
            {
                ret = _restaurantService.Delete(rvm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return ret;
        }

        [HttpDelete("DeleteRestaurantById")]
        public bool Delete(Guid guid)
        {
            bool ret = false;

            try
            {
                ret = _restaurantService.Delete(guid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return ret;
        }

        [HttpPut("EditRestaurant")]
        public RestaurantViewModel Edit(RestaurantViewModel rvm)
        {
            try
            {
                rvm = _restaurantService.Edit(rvm);
            }
            catch (Exception ex)
            {
                rvm.Error.IsError = true;
                rvm.Error.ErrorMessage = ex.Message;
                _logger.LogError(ex.Message);
            }

            return rvm;
        }

        [HttpGet("GetRestaurant")]
        public RestaurantViewModel Get(Guid guid)
        {
            RestaurantViewModel ret = new RestaurantViewModel();

            try
            {
                ret = _restaurantService.Get(guid);
            }
            catch (Exception ex)
            {
                ret.Error.IsError = true;
                ret.Error.ErrorMessage = ex.Message;
                _logger.LogError(ex.Message);
            }

            return ret;
        }

    }
}
