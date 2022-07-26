using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Services.Models
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
