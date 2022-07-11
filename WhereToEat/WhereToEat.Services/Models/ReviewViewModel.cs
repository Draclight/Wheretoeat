using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class ReviewViewModel :BaseViewModel
    {
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public string ReviewMark { get; set; }
        public DateTime ReviewDate { get; set; }
        public UserViewModel User { get; set; }
        public RestaurantViewModel Restaurant { get; set; }

    }
}
