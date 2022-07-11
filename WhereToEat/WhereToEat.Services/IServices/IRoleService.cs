using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface IRoleService : IBaseService
    {
        public RoleViewModel Add(RoleViewModel rvm);
        public RoleViewModel Get(int Id);
        public IList<RoleViewModel> GetAll();
        public RoleViewModel Edit(RoleViewModel rvm);
        public bool Delete(RoleViewModel rvm);
    }
}
