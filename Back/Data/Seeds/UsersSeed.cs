using CohorteApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CohorteApi.Data.Seeds
{
    public static class UsersSeed
    {

        public static void GetData(ModelBuilder modelBuilder)
        {
            var roles = new[]
            {
              new IdentityRole() { Id =  Guid.NewGuid().ToString(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
              new IdentityRole() { Id =  Guid.NewGuid().ToString(), Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


            var password = "Tiketfan123!";

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            var objs = new[]
            {
                new AppUser(){UserName = "nadir", Email = "nadir@mailinator.com"},
                new AppUser(){UserName = "alex", Email = "alex@mailinator.com"},
                new AppUser(){UserName = "diego", Email = "diego@mailinator.com"},
                new AppUser(){UserName = "max", Email = "max@mailinator.com"},
                new AppUser(){UserName = "manuel", Email = "manuel@mailinator.com"},
                new AppUser(){UserName = "any", Email = "any@mailinator.com"},
                new AppUser(){UserName = "bel", Email = "bel@mailinator.com"},
                new AppUser(){UserName = "d", Email = "d@mailinator.com"},
            };

            var userRoleId = roles.Last().Id;

            foreach (var item in objs)
            {
                item.PasswordHash = passwordHasher.HashPassword(item, password);
                item.NormalizedEmail = item.Email.ToUpper();
                item.NormalizedUserName = item.UserName.ToUpper();
                modelBuilder.Entity<AppUser>().HasData(item);
            }

            foreach (var item in objs)
            {
                var userRole = new IdentityUserRole<string>() { RoleId = userRoleId, UserId = item.Id };
                _ = modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
            }
        }
    }

    [Obsolete]
    public static class RolesSeed
    {
        public static IEnumerable<IdentityRole> GetData()
        {
            var objs = new[]
            {
                new IdentityRole(){ Name = "Admin" , NormalizedName = "ADMIN"},
                new IdentityRole(){ Name = "User" , NormalizedName = "USER"},
            };
            return objs;
        }
    }
}
