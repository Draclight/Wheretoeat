using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddresse { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantPostaleCode { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantPhone { get; set; }
        public string RestaurantMark { get; set; }

        public User SuggestedBy { get; set; }
        public Company Company { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}
