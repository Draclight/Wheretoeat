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
    public class RoleService : IRoleService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public RoleViewModel Add(RoleViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(RoleViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public RoleViewModel Edit(RoleViewModel rvm)
        {
            throw new NotImplementedException();
        }

        public RoleViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<RoleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
