using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface IRestaurantService : IBaseService
    {
        public RestaurantViewModel Add(RestaurantViewModel rvm);
        public RestaurantViewModel Get(Guid Id);
        public IList<RestaurantViewModel> GetAll();
        public RestaurantViewModel Edit(RestaurantViewModel rvm);
        public bool Delete(RestaurantViewModel rvm);
        public bool Delete(Guid guid);
        public bool UpdateProba(RestaurantViewModel rvm);
        public IList<RestaurantViewModel> SelectR();
        public RestaurantViewModel SelectR(Guid companyId);
    }
}
