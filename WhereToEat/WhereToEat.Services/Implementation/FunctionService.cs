using Microsoft.EntityFrameworkCore;
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
    public class FunctionService : IFunctionService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();

        public FunctionViewModel Add(FunctionViewModel fvm)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Function f = new Function
                {
                    FunctionName = fvm.FunctionName,
                    Company = dbContext.Companies.Find(fvm.Company.Id),
                    CreatedDate = dateTime,
                    UpdatedDate = dateTime
                };
                dbContext.Attach(f).State = EntityState.Added;
                dbContext.Functions.Add(f);
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return fvm;
        }

        public bool Delete(FunctionViewModel fvm)
        {
            bool ret = false;
            try
            {
                ret = Delete(fvm.Id);
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
                Function f = dbContext.Functions.FirstOrDefault(f => f.Id.Equals(guid));
                if (f != null)
                {
                    dbContext.Attach(f).State = EntityState.Deleted;
                    dbContext.Functions.Remove(f);
                    dbContext.SaveChanges();
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }

        public FunctionViewModel Edit(FunctionViewModel fvm)
        {
            try
            {
                Function f = new Function
                {
                    Id = fvm.Id,
                    FunctionName = fvm.FunctionName,
                    Company = dbContext.Companies.Find(fvm.Company.Id),
                    UpdatedDate = DateTime.Now
                };
                dbContext.Attach(f).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return fvm;
        }

        public FunctionViewModel Get(Guid Id)
        {
            FunctionViewModel ret = null;

            try
            {
                Function f = dbContext.Functions.Include(f => f.Company).First(f => f.Id == Id);

                if (f is not null)
                {
                    ret = new FunctionViewModel
                    {
                        Id = f.Id,
                        Company = new CompanyViewModel
                        {
                            Id = f.Company.Id,
                            CompanyName = f.Company.CompanyName
                        },
                        FunctionName = f.FunctionName,
                        CreatedDate = f.CreatedDate,
                        UpdatedDate = f.UpdatedDate
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return ret;
        }

        public IList<FunctionViewModel> GetAll()
        {
            IList<FunctionViewModel> ret = null;

            try
            {
                IQueryable<Function> resQuery = from f in dbContext.Functions
                                                join c in dbContext.Companies on f.Company.Id equals c.Id
                                                select f;

                ret = resQuery.Select(f => new FunctionViewModel
                {
                    Id = f.Id,
                    FunctionName = f.FunctionName,
                    CreatedDate = f.CreatedDate,
                    UpdatedDate = f.UpdatedDate,
                    Company = new CompanyViewModel
                    {
                        Id = f.Company.Id,
                        CompanyName = f.Company.CompanyName,
                        RegisteredDate = f.Company.RegisteredDate,
                        CreatedDate = f.Company.CreatedDate,
                        UpdatedDate = f.Company.UpdatedDate,
                    },
                    FunctionUsers = f.FunctionUsers.Select(fu => new UserViewModel
                    {
                        Id = Guid.Parse(fu.Id),
                        Company = new CompanyViewModel
                        {
                            Id = f.Company.Id,
                            CompanyName = f.Company.CompanyName,
                            RegisteredDate = f.Company.RegisteredDate,
                            CreatedDate = f.Company.CreatedDate,
                            UpdatedDate = f.Company.UpdatedDate,
                        },
                        UserName = fu.UserName,
                        NormalizedUserName = fu.NormalizedUserName,
                        Email = fu.Email,
                        NormalizedEmail = fu.NormalizedEmail,
                        EmailConfirmed = fu.EmailConfirmed,
                        PasswordHash = fu.PasswordHash,
                        SecurityStamp = fu.SecurityStamp,
                        ConcurrencyStamp = fu.ConcurrencyStamp,
                        PhoneNumber = fu.PhoneNumber,
                        PhoneNumberConfirmed = fu.PhoneNumberConfirmed,
                        TwoFactorEnabled = fu.TwoFactorEnabled,
                        LockoutEnd = fu.LockoutEnd,
                        LockoutEnabled = fu.LockoutEnabled,
                        AccessFailedCount = fu.AccessFailedCount
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
