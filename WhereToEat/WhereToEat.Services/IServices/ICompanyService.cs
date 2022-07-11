using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface ICompanyService : IBaseService
    {
        public CompanyViewModel Add(CompanyViewModel cvm);
        public CompanyViewModel Get(Guid Id);
        public IList<CompanyViewModel> GetAll();
        public CompanyViewModel Edit(CompanyViewModel cvm);
        public bool Delete(CompanyViewModel cvm);
        public bool Delete(Guid guid);

    }
}
