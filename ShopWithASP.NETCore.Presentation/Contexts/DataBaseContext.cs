using Microsoft.EntityFrameworkCore;
using ShopWithASP.NETCore.Application.Interfaces.Contexts;
using ShopWithASP.NETCore.Common.Roles;
using ShopWithASP.NETCore.Doima.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithASP.NETCore.Presentation.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions _options):base(_options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>().HasData(new Role { RoleId=1, Name="Admin"});
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 3, Name = nameof(UserRoles.Customer) });

            // اعمال ایندکس بر روی فیلد ایمیل واعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
