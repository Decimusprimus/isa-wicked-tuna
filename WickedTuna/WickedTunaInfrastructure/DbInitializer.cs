using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Auth;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            dbContext.Database.EnsureCreated();

            if(dbContext.Instructors.Any())
            {
                return;
            }

            SeedRoles(roleManager);
            SeedUsers(dbContext, userManager);


        }

        public static void SeedUsers(WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser() { Email = "marko.ppekez25@gmail.com", UserName = "marko.ppekez25@gmail.com", EmailConfirmed = true};
            var res = userManager.CreateAsync(user, "Instructor1*").Result;
            if(res.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Instructor").Wait();
            }

            var instructor = new Instructor()
            {
                ApplicationUser = user,
                Email = "marko.ppekez25@gmail.com",
                Name = "Pero", 
                Surname = "Simo",
                County = "Serbia",
                City = "Novi Sad", 
                StreetName = "Branka Bajica 24",
            };
            dbContext.Instructors.Add(instructor);
            dbContext.SaveChanges();

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if(!roleManager.RoleExistsAsync("Instructor").Result)
            {
                var role = new IdentityRole();
                role.Name = "Instructor";
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
