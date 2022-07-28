using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class BaseListViewModel<T> : List<T>
    {
        public class ErrorViewModel
        {
            public bool IsError { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
