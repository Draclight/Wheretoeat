using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class User : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Company Company { get; set; }
        public Function Function { get; set; }
        public IList<Restaurant> RestaurantsSuggested { get; set; }
        public IList<Review> ReviewsMade { get; set; }
        public IList<UserRoles> UserRoles { get; set; }
    }
}
