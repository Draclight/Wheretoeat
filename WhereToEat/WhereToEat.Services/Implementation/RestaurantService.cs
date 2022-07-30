using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
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
    public class RestaurantService : IRestaurantService
    {
        public WhereToEatContext dbContext => new WhereToEatContext();
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "OnMangeOu";
        static readonly string SpreadsheetId = "1Zop0s06ILvEf6EI7ti7i3HpcdBEEihfA1aE8B0V2j74";
        static readonly string Sheet = "Restaurants";
        static SheetsService Service;

        public RestaurantViewModel Add(RestaurantViewModel rvm)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Restaurant r = new Restaurant
                {
                    RestaurantName = rvm.RestaurantName,
                    Company = dbContext.Companies.Find(rvm.Company.Id),
                    SuggestedBy = dbContext.Users.Find(rvm.SuggestedBy.Id),
                    RestaurantAddresse = rvm.RestaurantAddresse,
                    RestaurantCity = rvm.RestaurantCity,
                    RestaurantDescription = rvm.RestaurantDescription,
                    RestaurantMark = "NULL",
                    RestaurantPhone = rvm.RestaurantPhone,
                    RestaurantPostaleCode = rvm.RestaurantPostaleCode,
                    CreatedDate = dateTime,
                    UpdatedDate = dateTime
                };
                dbContext.Attach(r).State = EntityState.Added;
                dbContext.Restaurants.Add(r);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rvm;
        }

        public bool Delete(RestaurantViewModel rvm)
        {
            bool ret = false;

            try
            {
                ret = Delete(rvm.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ret;
        }

        public bool Delete(Guid guid)
        {
            bool ret = false;

            try
            {
                Restaurant r = dbContext.Restaurants.FirstOrDefault(r => r.Id.Equals(guid));
                if (r != null)
                {
                    dbContext.Attach(r).State = EntityState.Deleted;
                    dbContext.Restaurants.Remove(r);
                    dbContext.SaveChanges();
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ret;
        }

        public RestaurantViewModel Edit(RestaurantViewModel rvm)
        {
            try
            {
                Restaurant r = new Restaurant
                {
                    RestaurantName = rvm.RestaurantName,
                    Company = dbContext.Companies.Find(rvm.Company.Id),
                    SuggestedBy = dbContext.Users.Find(rvm.SuggestedBy.Id),
                    RestaurantAddresse = rvm.RestaurantAddresse,
                    RestaurantCity = rvm.RestaurantCity,
                    RestaurantDescription = rvm.RestaurantDescription,
                    RestaurantMark = rvm.RestaurantMark,
                    RestaurantPhone = rvm.RestaurantPhone,
                    RestaurantPostaleCode = rvm.RestaurantPostaleCode,
                    CreatedDate = rvm.CreatedDate,
                    UpdatedDate = DateTime.Now
                };
                dbContext.Attach(r).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rvm;
        }

        public RestaurantViewModel Get(Guid Id)
        {
            RestaurantViewModel ret = null;

            try
            {
                Restaurant r = dbContext.Restaurants.Include(r => r.Company).Include(r => r.SuggestedBy).First(r => r.Id == Id);

                if (r is not null)
                {
                    ret = new RestaurantViewModel
                    {
                        Id = r.Id,
                        Company = new CompanyViewModel
                        {
                            Id = r.Company.Id,
                            CompanyName = r.Company.CompanyName,
                            RegisteredDate = r.Company.RegisteredDate
                        },
                        RestaurantName = r.RestaurantName,
                        SuggestedBy = new UserViewModel
                        {
                            Id = Guid.Parse(r.SuggestedBy.Id),
                            UserName = r.SuggestedBy.UserName,
                            NormalizedUserName = r.SuggestedBy.NormalizedUserName,
                            Email = r.SuggestedBy.Email,
                            NormalizedEmail = r.SuggestedBy.NormalizedEmail,
                            EmailConfirmed = r.SuggestedBy.EmailConfirmed,
                            PasswordHash = r.SuggestedBy.PasswordHash,
                            SecurityStamp = r.SuggestedBy.SecurityStamp,
                            ConcurrencyStamp = r.SuggestedBy.ConcurrencyStamp,
                            PhoneNumber = r.SuggestedBy.PhoneNumber,
                            PhoneNumberConfirmed = r.SuggestedBy.PhoneNumberConfirmed,
                            TwoFactorEnabled = r.SuggestedBy.TwoFactorEnabled,
                            LockoutEnd = r.SuggestedBy.LockoutEnd,
                            LockoutEnabled = r.SuggestedBy.LockoutEnabled,
                            AccessFailedCount = r.SuggestedBy.AccessFailedCount
                        },
                        RestaurantAddresse = r.RestaurantAddresse,
                        RestaurantCity = r.RestaurantCity,
                        RestaurantDescription = r.RestaurantDescription,
                        RestaurantMark = r.RestaurantMark,
                        RestaurantPhone = r.RestaurantPhone,
                        RestaurantPostaleCode = r.RestaurantPostaleCode,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ret;
        }

        //public IList<RestaurantViewModel> GetAll()
        //{
        //    IList<RestaurantViewModel> ret = null;

        //    try
        //    {
        //        IQueryable<Restaurant> resQuery = from r in dbContext.Restaurants
        //                                          join u in dbContext.Users on r.SuggestedBy.Id equals u.Id
        //                                          join c in dbContext.Companies on r.Company.Id equals c.Id
        //                                          select r;

        //        ret = resQuery.Select(r => new RestaurantViewModel
        //        {
        //            Id = r.Id,
        //            Company = new CompanyViewModel
        //            {
        //                Id = r.Company.Id,
        //                CompanyName = r.Company.CompanyName,
        //                RegisteredDate = r.Company.RegisteredDate
        //            },
        //            RestaurantName = r.RestaurantName,
        //            SuggestedBy = new UserViewModel
        //            {
        //                Id = Guid.Parse(r.SuggestedBy.Id),
        //                UserName = r.SuggestedBy.UserName,
        //                NormalizedUserName = r.SuggestedBy.NormalizedUserName,
        //                Email = r.SuggestedBy.Email,
        //                NormalizedEmail = r.SuggestedBy.NormalizedEmail,
        //                EmailConfirmed = r.SuggestedBy.EmailConfirmed,
        //                PasswordHash = r.SuggestedBy.PasswordHash,
        //                SecurityStamp = r.SuggestedBy.SecurityStamp,
        //                ConcurrencyStamp = r.SuggestedBy.ConcurrencyStamp,
        //                PhoneNumber = r.SuggestedBy.PhoneNumber,
        //                PhoneNumberConfirmed = r.SuggestedBy.PhoneNumberConfirmed,
        //                TwoFactorEnabled = r.SuggestedBy.TwoFactorEnabled,
        //                LockoutEnd = r.SuggestedBy.LockoutEnd,
        //                LockoutEnabled = r.SuggestedBy.LockoutEnabled,
        //                AccessFailedCount = r.SuggestedBy.AccessFailedCount
        //            },
        //            RestaurantAddresse = r.RestaurantAddresse,
        //            RestaurantCity = r.RestaurantCity,
        //            RestaurantDescription = r.RestaurantDescription,
        //            RestaurantMark = r.RestaurantMark,
        //            RestaurantPhone = r.RestaurantPhone,
        //            RestaurantPostaleCode = r.RestaurantPostaleCode,
        //            CreatedDate = r.CreatedDate,
        //            UpdatedDate = r.UpdatedDate
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine(ex.Message);
        //    }

        //    return ret;
        //}

        public RestaurantListViewModel GetAll()
        {
            RestaurantListViewModel ret = new RestaurantListViewModel();

            try
            {
                InitializeService();

                var range = $"{Sheet}";
                SpreadsheetsResource.ValuesResource.GetRequest request = Service.Spreadsheets.Values.Get(SpreadsheetId, range);

                var response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    foreach (var tempRestau in values.Skip(1))
                    {
                        DateTime date = string.IsNullOrEmpty(tempRestau[0].ToString()) ? DateTime.MinValue : DateTime.Parse(tempRestau[0].ToString());
                        string restaurantName = string.IsNullOrEmpty(tempRestau[1].ToString()) ? string.Empty : tempRestau[1].ToString();
                        string suggestedBy = string.IsNullOrEmpty(tempRestau[2].ToString()) ? string.Empty : tempRestau[2].ToString();
                        string restaurantAddresse = string.IsNullOrEmpty(tempRestau[3].ToString()) ? string.Empty : tempRestau[3].ToString();
                        string restaurantDescription = string.IsNullOrEmpty(tempRestau[4].ToString()) ? string.Empty : tempRestau[4].ToString();
                        string restaurantMark = string.IsNullOrEmpty(tempRestau[4].ToString()) ? string.Empty : tempRestau[12].ToString();

                        RestaurantViewModel rvm = new RestaurantViewModel
                        {
                            CreatedDateString = date.ToShortDateString(),
                            RestaurantName = restaurantName,
                            SuggestedBy = new UserViewModel
                            {
                                UserName = suggestedBy
                            },
                            RestaurantAddresse = restaurantAddresse,
                            RestaurantDescription = restaurantDescription,
                            RestaurantMark = restaurantMark
                        };

                        ret.Add(rvm);
                    }
                }
                else
                {
                    throw new Exception("No data found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public RestaurantViewModel SelectR(Guid companyId)
        {
            RestaurantViewModel ret = null;
            //bool isResultOk = false;
            //int selectedId = 0;
            //var rs = from r in dbContext.Restaurants
            //                                join c in dbContext.Companies on r.Company.Id equals c.Id
            //                                where c.Id == companyId
            //                                select r;

            //do
            //{
            //    selectedId = new Random().Next(0, rs.Count - 1);
            //    ret = Get(selectedId);
            //    isResultOk = true;
            //} while (isResultOk != true);

            //ret.NumberSelectedTimes++;
            //UpdateProba(ret);

            return ret;
        }

        public RestaurantViewModel SelectR()
        {
            RestaurantViewModel ret = new RestaurantViewModel();

            try
            {
                InitializeService();
                var range = $"{Sheet}";
                SpreadsheetsResource.ValuesResource.GetRequest request = Service.Spreadsheets.Values.Get(SpreadsheetId, range);

                var response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    int index = new Random().Next(0, values.Count - 1);
                    IList<object> tempRestau = values.ElementAt(index);
                    DateTime date = string.IsNullOrEmpty(tempRestau[0].ToString()) ? DateTime.MinValue : DateTime.Parse(tempRestau[0].ToString());
                    string RestaurantName = string.IsNullOrEmpty(tempRestau[1].ToString()) ? string.Empty : tempRestau[1].ToString();
                    string suggestedBy = string.IsNullOrEmpty(tempRestau[2].ToString()) ? string.Empty : tempRestau[2].ToString();
                    string restaurantAddresse = string.IsNullOrEmpty(tempRestau[3].ToString()) ? string.Empty : tempRestau[3].ToString();
                    string restaurantDescription = string.IsNullOrEmpty(tempRestau[4].ToString()) ? string.Empty : tempRestau[4].ToString();
                    string restaurantMark = string.IsNullOrEmpty(tempRestau[4].ToString()) ? string.Empty : tempRestau[12].ToString();

                    ret = new RestaurantViewModel
                    {
                        CreatedDate = date,
                        CreatedDateString = date.ToShortDateString(),
                        RestaurantName = RestaurantName,
                        SuggestedBy = new UserViewModel
                        {
                            UserName = suggestedBy
                        },
                        RestaurantAddresse = restaurantAddresse,
                        RestaurantDescription = restaurantDescription,
                        RestaurantMark = restaurantMark
                    };
                }
                else
                {
                    throw new Exception("No data found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public RestaurantViewModel SelectR2()
        {
            RestaurantViewModel ret = new RestaurantViewModel();

            try
            {
                RestaurantListViewModel restaurants = GetAll();
                int numberOfRestaurants = restaurants.Count;
                var rdn = new Random(Guid.NewGuid().GetHashCode());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public bool UpdateProba(RestaurantViewModel rvm)
        {
            bool ret = false;
            var rs = from r in dbContext.Restaurants
                     join c in dbContext.Companies on r.Company.Id equals c.Id
                     where c.Id == rvm.Company.Id
                     select r;

            try
            {
                Restaurant r = dbContext.Restaurants.Find(rvm.Id);
                if (r == null)
                    throw new Exception("Error update proba on restaurant");
                else
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        private void InitializeService()
        {
            GoogleCredential credential;

            try
            {
                using (var stream = new FileStream(@"./on-mange-ou-331619-163024a51200.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                }

                // Create Google Sheets API service.
                Service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MyError : {ex.Message} - Date {DateTime.Now}");
                throw ex;
            }
        }
    }
}

