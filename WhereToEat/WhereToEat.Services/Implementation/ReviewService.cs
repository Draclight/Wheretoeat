using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Data.Data;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public ReviewViewModel Add(ReviewViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ReviewViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public ReviewViewModel Edit(ReviewViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public ReviewViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<ReviewViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
