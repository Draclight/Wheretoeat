using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Core.Models
{
    public class Review : BaseEntity
    {
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public string ReviewMark { get; set; }
        public DateTime ReviewDate { get; set; }

        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
