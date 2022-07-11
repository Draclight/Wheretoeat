using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class UserRolesViewModel : BaseViewModel
    {
        public UserViewModel User { get; set; }
        public RoleViewModel Role { get; set; }
    }
}
