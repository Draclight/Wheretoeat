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
    public class UserService : IUserService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public UserViewModel Add(UserViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public UserViewModel Edit(UserViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public UserViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
