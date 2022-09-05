using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Core.Models;
using System.Configuration;

namespace WhereToEat.Data.Data
{
    public class WhereToEatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=192.165.85.132;Database=WhereToEat_dev;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(@"Server=192.165.85.132;Database=WhereToEat_dev;User Id=sa;Password=1K37Sp4=@K$E!0gJb`4;");
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
