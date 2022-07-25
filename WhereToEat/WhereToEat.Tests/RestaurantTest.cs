using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Tests
{
    public class RestaurantTest
    {
        private IRestaurantService _restaurantService;
        [SetUp]
        public void Setup()
        {
            _restaurantService = new RestaurantService();
        }

        [Test]
        public void TestSelectR()
        {
            var viewModel = _restaurantService.SelectR();
            Assert.IsNotNull(viewModel);
        }
    }
}