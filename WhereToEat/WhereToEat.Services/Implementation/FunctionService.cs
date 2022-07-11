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
    public class FunctionService : IFunctionService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public FunctionViewModel Add(FunctionViewModel fvm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(FunctionViewModel fvm)
        {
            throw new NotImplementedException();
        }

        public FunctionViewModel Edit(FunctionViewModel fvm)
        {
            throw new NotImplementedException();
        }

        public FunctionViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<FunctionViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
