using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class FunctionViewModel : BaseViewModel
    {
        public string FunctionName { get; set; }

        public CompanyViewModel Company { get; set; }
        public IList<UserViewModel> FunctionUsers { get; set; }
    }
}
