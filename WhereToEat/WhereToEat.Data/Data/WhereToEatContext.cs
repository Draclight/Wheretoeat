using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Core.Models;
using System.Configuration;
using WhereToEat.Data.Helper;
using Microsoft.Extensions.Configuration;

namespace WhereToEat.Data.Data
{
    public class WhereToEatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = string.Empty;
            IConfigurationRoot config = null;

            try
            {
                config = ConfigHelper.Load();
                #if (DEBUG)
                    connectionString = config.GetSection("connetionString").Value;
                #elif (TEST)
                    connectionString = config.GetSection("connetionStringRec").Value;
                #elif (RELEASE)
                    config = ConfigHelper.Load(Env.prod);
                #endif
            }
            catch (Exception ex)
            {
                throw;
            }

            optionsBuilder.UseSqlServer(@connectionString);
        }

        private string getString(string environment)
        {
            return string.Empty;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
