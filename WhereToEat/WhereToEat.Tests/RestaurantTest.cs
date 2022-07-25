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
        public void TestSelectRIsNull()
        {
            var viewModel = _restaurantService.SelectR();
            Assert.IsNull(viewModel);
        }

        [Test]
        public void TestSelectRIsNotNull()
        {
            var viewModel = _restaurantService.SelectR();
            Assert.IsNotNull(viewModel);
        }

        [Test]
        public void TestSelectRIsEmpty()
        {
            var viewModel = _restaurantService.SelectR();
            if (viewModel != null)
            {
                Assert.IsEmpty(viewModel);
            }
        }

        [Test]
        public void TestSelectRIsNotEmpty()
        {
            var viewModel = _restaurantService.SelectR();
            if (viewModel != null)
            {
                Assert.IsNotEmpty(viewModel);
            }
        }
    }
}