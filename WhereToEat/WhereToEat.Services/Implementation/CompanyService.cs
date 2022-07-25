using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Core.Models;
using WhereToEat.Data.Data;
using WhereToEat.Services.IServices;
using WhereToEat.Services.Models;

namespace WhereToEat.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public CompanyViewModel Add(CompanyViewModel cvm)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Company company = new Company
                {
                    CompanyName = cvm.CompanyName,
                    RegisteredDate = cvm.RegisteredDate,
                    CreatedDate = dateTime,
                    UpdatedDate = dateTime                    
                };
                dbContext.Attach(company).State = EntityState.Added;
                dbContext.Companies.Add(company);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return cvm;
        }

        public bool Delete(CompanyViewModel cvm)
        {
            bool ret = false;
            try
            {
                ret = Delete(cvm.Id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }

        public bool Delete(Guid guid)
        {

            bool ret = false;
            try
            {
                Company company = dbContext.Companies.FirstOrDefault(c => c.Id.Equals(guid));
                dbContext.Attach(company).State = EntityState.Deleted;
                dbContext.Companies.Remove(company);
                dbContext.SaveChanges();
                ret = true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }

        public CompanyViewModel Edit(CompanyViewModel cvm)
        {
            try
            {
                Company c = new Company
                {
                    Id = cvm.Id,
                    CompanyName = cvm.CompanyName,
                    RegisteredDate = cvm.RegisteredDate,
                    UpdatedDate = DateTime.Now,
                };
                dbContext.Attach(c).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return cvm;
        }

        public CompanyViewModel Get(Guid Id)
        {
            CompanyViewModel ret = null;

            try
            {
                Company c = dbContext.Companies.First(c => c.Id == Id);

                if (c is not null)
                {
                    ret = new CompanyViewModel
                    {
                        Id = c.Id,
                        CompanyName = c.CompanyName,
                        RegisteredDate = c.RegisteredDate,
                        CreatedDate = c.CreatedDate,
                        UpdatedDate = c.UpdatedDate
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }

        public IList<CompanyViewModel> GetAll()
        {
            IList<CompanyViewModel> ret = null;

            try
            {
                IQueryable<Company> resQuery = from c in dbContext.Companies
                                               join u in dbContext.Users on c.Id equals u.Company.Id
                                                    join fU in dbContext.Functions on u.Function.Id equals fU.Id
                                               join r in dbContext.Restaurants on c.Id equals r.Company.Id
                                               join f in dbContext.Functions on c.Id equals f.Company.Id
                                               select c;

                ret = resQuery.Select(c => new CompanyViewModel
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    RegisteredDate = c.RegisteredDate,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate,
                    CompanyUsers = c.CompanyUsers.Select(u => new UserViewModel
                    {
                        Id = Guid.Parse(u.Id),
                        AccessFailedCount = u.AccessFailedCount,
                        ConcurrencyStamp = u.ConcurrencyStamp,
                        CreatedDate = u.CreatedDate,
                        Email = u.Email,
                        EmailConfirmed = u.EmailConfirmed,
                        Function = new FunctionViewModel
                        {

                        },
                    }).ToList(),
                    Functions = c.Functions.Select(f => new FunctionViewModel
                    {
                        Id = f.Id,
                    }).ToList(),
                    Restaurants = c.Restaurants.Select(r => new RestaurantViewModel
                    {
                        Id = r.Id
                    }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }
    }
}
