using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.IServices
{
    public interface IFunctionService : IBaseService
    {
        public FunctionViewModel Add(FunctionViewModel fvm);
        public FunctionViewModel Get(Guid Id);
        public IList<FunctionViewModel> GetAll();
        public FunctionViewModel Edit(FunctionViewModel fvm);
        public bool Delete(FunctionViewModel fvm);
        public bool Delete(Guid guid);
    }
}
