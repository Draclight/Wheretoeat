using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class Function : BaseEntity
    {
        public string FunctionName { get; set; }

        public Company Company { get; set; }
        public IList<IdentityUser> FunctionUsers { get; set; }
    }
}
