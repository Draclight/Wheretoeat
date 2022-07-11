using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class RestaurantViewModel : BaseViewModel
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddresse { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantPostaleCode { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantPhone { get; set; }
        public string RestaurantMark { get; set; }
        public UserViewModel SuggestedBy { get; set; }
        public CompanyViewModel Company { get; set; }
        public IList<ReviewViewModel> Reviews { get; set; }

    }
}
