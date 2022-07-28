using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class RestaurantListViewModel : BaseListViewModel<RestaurantViewModel>
    {
        public RestaurantListViewModel()
        {
            Error = new ErrorViewModel();
        }
        public ErrorViewModel Error { get; set; }
    }
}
