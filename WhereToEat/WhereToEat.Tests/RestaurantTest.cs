using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Tests
{
    public class RestaurantTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SelectR_IsNotNull()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();
            
            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.IsNotNull(viewModel);
        }

        [Test]
        public void SelectR_CreatedDateIsGreaterThanMinimum()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();

            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.Greater(viewModel.CreatedDate, DateTime.MinValue);
        }

        [Test]
        public void SelectR_CreatedDateStringIsNotNull()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();

            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.IsNotNull(viewModel.CreatedDateString);
        }

        [Test]
        public void SelectR_RestaurantNameIsNotNull()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();

            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.IsNotNull(viewModel.RestaurantName);
        }

        [Test]
        public void SelectR_SuggestedByIsNotNull()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();

            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.IsNotNull(viewModel.SuggestedBy);
        }

        [Test]
        public void SelectR_RestaurantDescriptionIsNotNull()
        {
            // Arrange
            IRestaurantService _restaurantService = new RestaurantService();

            // Act
            var viewModel = _restaurantService.SelectRestaurant();

            // Assert
            Assert.IsNotNull(viewModel.RestaurantDescription);
        }
    }
}