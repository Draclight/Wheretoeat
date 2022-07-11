using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Data.Data;

namespace WhereToEat.Services.IServices
{
    public interface IBaseService
    {
        WhereToEatContext dbContext { get; }
    }
}
