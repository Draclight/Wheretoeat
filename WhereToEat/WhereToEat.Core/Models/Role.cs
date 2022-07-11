using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class Role : IdentityRole
    {
        public IList<UserRoles> UserRoles { get; set; }
    }
}
