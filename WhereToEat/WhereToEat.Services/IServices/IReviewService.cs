using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface IReviewService : IBaseService
    {
        public ReviewViewModel Add(ReviewViewModel rvm);
        public ReviewViewModel Get(int Id);
        public IList<ReviewViewModel> GetAll();
        public ReviewViewModel Edit(ReviewViewModel rvm);
        public bool Delete(ReviewViewModel rvm);
    }
}
