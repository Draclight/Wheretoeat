using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface IUserService : IBaseService
    {
        public UserViewModel Add(UserViewModel rvm);
        public UserViewModel Get(int Id);
        public IList<UserViewModel> GetAll();
        public UserViewModel Edit(UserViewModel rvm);
        public bool Delete(UserViewModel rvm);
    }
}
