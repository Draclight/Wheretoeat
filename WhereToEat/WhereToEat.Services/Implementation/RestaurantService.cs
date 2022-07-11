using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Data.Data;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public RestaurantViewModel Add(RestaurantViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(RestaurantViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public RestaurantViewModel Edit(RestaurantViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public RestaurantViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<RestaurantViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RestaurantViewModel SelectR()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProba(RestaurantViewModel rvm)
        {
            throw new NotImplementedException();
        }
    }
}
