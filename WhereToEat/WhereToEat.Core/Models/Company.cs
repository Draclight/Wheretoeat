using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public DateTime RegisteredDate { get; set; }

        public IList<Function> Functions { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
        public IList<User> CompanyUsers { get; set; }
    }
}
