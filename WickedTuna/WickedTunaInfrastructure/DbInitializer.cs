using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Auth;
using WickedTunaCore.Common;
using WickedTunaCore.Cottages;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            dbContext.Database.EnsureCreated();

            if(dbContext.CottageOwners.Any())
            {
                return;
            }

            SeedRoles(roleManager);
            SeedUsers(dbContext, userManager);


        }

        public static void SeedUsers(WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
           /* var user = new ApplicationUser() { Email = "marko.ppekez25@gmail.com", UserName = "marko.ppekez25@gmail.com", EmailConfirmed = true};
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
            dbContext.SaveChanges();*/



            var userCottageOwner1 = new ApplicationUser() { Email = "cottage.owner1@mail.com", UserName = "cottage.owner1@mail.com", EmailConfirmed = true };
            var userCottageOwner1Result = userManager.CreateAsync(userCottageOwner1, "CottageOwner1*").Result;
            if(userCottageOwner1Result.Succeeded)
            {
                userManager.AddToRoleAsync(userCottageOwner1, "CottageOwner").Wait();
            }
            var cottageOwner1 = new CottageOwner()
            {
                ApplicationUser = userCottageOwner1,
                Email = "cottage.owner1@mail.com",
                Name = "Simo",
                Surname = "Simic",
                County = "Serbia",
                City = "Belgrade",
                StreetName = "Krusevacka",
                PhoneNumber = "38160564689",
            };
            dbContext.CottageOwners.Add(cottageOwner1);
            dbContext.SaveChanges();

            var userCottageOwner2 = new ApplicationUser() { Email = "cottage.owner2@mail.com", UserName = "cottage.owner2@mail.com", EmailConfirmed = true };
            var userCottageOwner2Result = userManager.CreateAsync(userCottageOwner2, "CottageOwner2*").Result;
            if (userCottageOwner2Result.Succeeded)
            {
                userManager.AddToRoleAsync(userCottageOwner2, "CottageOwner").Wait();
            }
            var cottageOwner2 = new CottageOwner()
            {
                ApplicationUser = userCottageOwner2,
                Email = "cottage.owner2@mail.com",
                Name = "Djuro",
                Surname = "Masnikovic",
                County = "Serbia",
                City = "Novi Sad",
                StreetName = "Hajduk Veljkova",
                PhoneNumber = "38161545844",
            };
            dbContext.CottageOwners.Add(cottageOwner2);
            dbContext.SaveChanges();

            var userCottageOwner3 = new ApplicationUser() { Email = "cottage.owner3@mail.com", UserName = "cottage.owner3@mail.com", EmailConfirmed = true };
            var userCottageOwner3Result = userManager.CreateAsync(userCottageOwner3, "CottageOwner3*").Result;
            if (userCottageOwner3Result.Succeeded)
            {
                userManager.AddToRoleAsync(userCottageOwner3, "CottageOwner").Wait();
            }
            var cottageOwner3 = new CottageOwner()
            {
                ApplicationUser = userCottageOwner3,
                Email = "cottage.owner3@mail.com",
                Name = "Petar",
                Surname = "Djuric",
                County = "Serbia",
                City = "Novi Sad",
                StreetName = "Janka Cmelika",
                PhoneNumber = "38161547833",
            };
            dbContext.CottageOwners.Add(cottageOwner3);
            dbContext.SaveChanges();


            var cottage11 = new Cottage()
            {
                Id = new Guid(),
                Name = "Holiday Home",
                Address = new Address()
                {
                    County = "Serba",
                    City = "Kopaonik",
                    Street = "Treska"
                },
                Description = "Objekat Holiday Home se nalazi na Kopaoniku, na 6 km od Ski-centra Kopaonik. U ponudi je smeštaj sa pogledom na planinu. Gosti mogu da koriste vrt, pribor za pripremu roštilja, besplatan WiFi i besplatan privatni parking.",
                Price = 3000.0f,
                CottageOwner = cottageOwner1,
                AdditionalServices = "besplatan parking, besplatan WiFi",
            };
            dbContext.Cottages.Add(cottage11);

            var cottage21 = new Cottage()
            {
                Name = "Vila Gago",
                Address = new Address()
                {
                    County = "Serba",
                    City = "Novi Sad",
                    Street = "Kamenicki put"
                },
                Description = "Objekat Vila Gago nudi besplatan WiFi i pogled na grad. Smešten je u Novom Sadu, na samo 1,7 km od tržnog centra Promenada i 200 metara od mesta održavanja Festivala Exit. Nalazi se na 1,3 km od sportskog centra SPENS i raspolaže vrtom i besplatnim privatnim parkingom.",
                Price = 3000.0f,
                CottageOwner = cottageOwner2,
                AdditionalServices = "besplatan parking, besplatan WiFi, dozvoljeni kucni ljubimci",
            };
            dbContext.Cottages.Add(cottage21);

            var cottage22 = new Cottage()
            {
                Name = "Yellow house",
                Address = new Address()
                {
                    County = "Serba",
                    City = "Novi Sad",
                    Street = "Ribnjak srednji put"
                },
                Description = "Objekat Yellow house je smešten u Novom Sadu, na 3,8 km od sportskog centra SPENS i 5 km od tržnog centra Promenada. Nudi sopstveni sezonski bazen na otvorenom, klima-uređaj, vrt i pribor za roštilj. WiFi i privatan parking se mogu besplatno koristiti.",
                Price = 3000.0f,
                CottageOwner = cottageOwner2,
                AdditionalServices = "besplatan parking, besplatan WiFi, dozvoljeni kucni ljubimci, bazen",
            };
            dbContext.Cottages.Add(cottage22);

            var cottage23 = new Cottage()
            {
                Name = "Mali Bor",
                Address = new Address()
                {
                    County = "Serba",
                    City = "Novi Sad",
                    Street = "Jasmina 109"
                },
                Description = "Vikendica ima 2 spavaće sobe, 1 kupatilo, posteljinu, peškire i flat-screen TV sa kablovskim kanalima. Takođe sadrži trpezariju, potpuno opremljenu kuhinju i popločano dvorište sa pogledom na reku.",
                Price = 2900.0f,
                CottageOwner = cottageOwner2,
                AdditionalServices = "besplatan parking, besplatan WiFi",
            };
            dbContext.Cottages.Add(cottage23);

            var cottage31 = new Cottage()
            {
                Name = "Vila",
                Address = new Address()
                {
                    County = "Serba",
                    City = "Zlatiborr",
                    Street = "Vodice"
                },
                Description = "Vila Delona je smeštena na Zlatiboru, na 7 km od Ski centra Tornik. U ponudi ima besplatan bežični internet i lokaciju koju okružuje priroda. Pored toga nudi besplatan parking u sklopu objekta.",
                Price = 2900.0f,
                CottageOwner = cottageOwner3,
                AdditionalServices = "besplatan parking, besplatan WiFi, dozvoljeni kucni ljubimci",
            };
            dbContext.Cottages.Add(cottage31);
            dbContext.SaveChanges();


            var cottageAvailablePeriod111 = new CottageAvailablePeriod()
            {
                Cottage = cottage11,
                Start = new DateTime(2022, 1, 1, 0, 0, 0),
                End = new DateTime(2022, 5, 3, 0, 0, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod111);

            var cottageAvailablePeriod112 = new CottageAvailablePeriod()
            {
                Cottage = cottage11,
                Start = new DateTime(2022, 9, 1, 0, 0, 0),
                End = new DateTime(2023, 2, 3, 0, 0, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod112);

            var cottageAvailablePeriod211 = new CottageAvailablePeriod()
            {
                Cottage = cottage21,
                Start = new DateTime(2022,2,1,0,0,0),
                End = new DateTime(2022,6,1,0,0,0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod211);

            var cottageAvailablePeriod212 = new CottageAvailablePeriod()
            {
                Cottage = cottage21,
                Start = new DateTime(2022, 6, 3, 0, 0, 0),
                End = new DateTime(2022, 9, 1, 0, 0, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod212);

            var cottageAvailablePeriod221 = new CottageAvailablePeriod()
            {
                Cottage = cottage22,
                Start = new DateTime(2022, 1, 1, 0, 0, 0),
                End = new DateTime(2022, 5, 1, 0, 0, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod221);

            var cottageAvailablePeriod222 = new CottageAvailablePeriod()
            {
                Cottage = cottage22,
                Start = new DateTime(2022, 7, 10, 0, 0, 0),
                End = new DateTime(2023, 1, 1, 0, 0, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod222);

            var cottageAvailablePeriod231 = new CottageAvailablePeriod()
            {
                Cottage = cottage23,
                Start = new DateTime(2022, 5, 4, 10, 0, 0),
                End = new DateTime(2022, 10, 1, 5, 50, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod231);

            var cottageAvailablePeriod311 = new CottageAvailablePeriod()
            {
                Cottage = cottage31,
                Start = new DateTime(2022, 7, 4, 10, 0, 0),
                End = new DateTime(2023, 10, 1, 5, 50, 0),
            };
            dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod311);

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

            if (!roleManager.RoleExistsAsync("CottageOwner").Result)
            {
                var role = new IdentityRole();
                role.Name = "CottageOwner";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("BoatOwner").Result)
            {
                var role = new IdentityRole();
                role.Name = "BoatOwner";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("SystemAdmin").Result)
            {
                var role = new IdentityRole();
                role.Name = "SystemAdmin";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Client").Result)
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.CreateAsync(role).Wait();
            }

        }
    }
}
