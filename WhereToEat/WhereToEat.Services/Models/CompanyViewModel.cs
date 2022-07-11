using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class CompanyViewModel : BaseViewModel
    {
        public string CompanyName { get; set; }
        public DateTime RegisteredDate { get; set; }

        public IList<FunctionViewModel> Functions { get; set; }
        public IList<RestaurantViewModel> Restaurants { get; set; }
        public IList<UserViewModel> CompanyUsers { get; set; }
    }
}
