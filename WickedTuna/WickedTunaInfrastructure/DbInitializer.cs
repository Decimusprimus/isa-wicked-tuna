using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.AdventuresLessons;
using WickedTunaCore.Auth;
using WickedTunaCore.Boats;
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

            SeedRoles(roleManager);
            SeedUsers(dbContext, userManager);


        }

        public static void SeedUsers(WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {

            #region Cottages
            if (!dbContext.CottageOwners.Any()) {
                var userCottageOwner1 = new ApplicationUser() { Email = "cottage.owner1@mail.com", UserName = "cottage.owner1@mail.com", EmailConfirmed = true };
                var userCottageOwner1Result = userManager.CreateAsync(userCottageOwner1, "CottageOwner1*").Result;
                if (userCottageOwner1Result.Succeeded)
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
                    Id = new Guid("35241d6f-275d-4744-bc00-58eb61b19ca8"),
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
                    CottageRooms = new List<CottageRoom>()
                {
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    }
                },
                    NumberOfRooms = 3,
                };
                dbContext.Cottages.Add(cottage11);

                var cottage21 = new Cottage()
                {
                    Id = new Guid("7a2b1a9c-bc02-415c-ae5d-6459997be90b"),
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
                    CottageRooms = new List<CottageRoom>()
                {
                    new CottageRoom()
                    {
                        Room = "Dnevna soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    }
                },
                    NumberOfRooms = 3,
                };
                dbContext.Cottages.Add(cottage21);

                var cottage22 = new Cottage()
                {
                    Id = new Guid("cf251f0e-e742-4506-b068-a0a68ab3da92"),
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
                    CottageRooms = new List<CottageRoom>()
                {
                    new CottageRoom()
                    {
                        Room = "Dnevna soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    }
                },
                    NumberOfRooms = 4,
                };
                dbContext.Cottages.Add(cottage22);

                var cottage23 = new Cottage()
                {
                    Id = new Guid("d71de2a1-1a33-496a-9169-7d316d734fe9"),
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
                    CottageRooms = new List<CottageRoom>()
                {
                    new CottageRoom()
                    {
                        Room = "Dnevna soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                },
                    NumberOfRooms = 3,
                };
                dbContext.Cottages.Add(cottage23);

                var cottage31 = new Cottage()
                {
                    Id = new Guid("f5f0513d-94f3-4bd8-8f9c-110b15cedbd7"),
                    Name = "Vila",
                    Address = new Address()
                    {
                        County = "Serba",
                        City = "Zlatiborr",
                        Street = "Vodice"
                    },
                    Description = "Vila  je smeštena na Zlatiboru, na 7 km od Ski centra Tornik. U ponudi ima besplatan bežični internet i lokaciju koju okružuje priroda. Pored toga nudi besplatan parking u sklopu objekta.",
                    Price = 2900.0f,
                    CottageOwner = cottageOwner3,
                    AdditionalServices = "besplatan parking, besplatan WiFi, dozvoljeni kucni ljubimci",
                    CottageRooms = new List<CottageRoom>()
                {
                    new CottageRoom()
                    {
                        Room = "Dnevna soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 2,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                    new CottageRoom()
                    {
                        Room = "Spavaca soba",
                        NumberOfBeds = 1,
                    },
                },
                    NumberOfRooms = 5,
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
                    Start = new DateTime(2022, 2, 1, 0, 0, 0),
                    End = new DateTime(2022, 6, 1, 0, 0, 0),
                };
                dbContext.CottageAvailablePeriods.Add(cottageAvailablePeriod211);

                var cottageAvailablePeriod212 = new CottageAvailablePeriod()
                {
                    Cottage = cottage21,
                    Start = new DateTime(2022, 6, 3, 0, 0, 0),
                    End = new DateTime(2022, 9, 20, 0, 0, 0),
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

                var cottageSpecialOffer11 = new CottageReservation()
                {
                    Cottage = cottage11,
                    NumberOfPeople = 3,
                    Price = 2500,
                    ReservationStatus = ReservationStatus.Acite,
                    ReservationType = ReservationType.Special_offer,
                    AdditionalServices = "besplatan parking",
                    Start = new DateTime(2023, 2, 4, 0, 0, 0),
                    End = new DateTime(2023, 2, 7, 0, 0, 0),
                    Client = null
                };
                dbContext.CottageReservations.Add(cottageSpecialOffer11);
                dbContext.SaveChanges();

            }
            #endregion


            #region Boats
            if (!dbContext.BoatOwners.Any()) {
                var userBoatOwner1 = new ApplicationUser() { Email = "boat.owner1@mail.com", UserName = "boat.owner1@mail.com", EmailConfirmed = true };
                var userBoatOwnerResult1 = userManager.CreateAsync(userBoatOwner1, "BoatOwner1*").Result;
                if (userBoatOwnerResult1.Succeeded)
                {
                    userManager.AddToRoleAsync(userBoatOwner1, "BoatOwner").Wait();
                }
                var boatOwner1 = new BoatOwner()
                {
                    ApplicationUser = userBoatOwner1,
                    Email = "boat.owner1@mail.com",
                    Name = "Nikola",
                    Surname = "Simic",
                    County = "Croatia",
                    City = "Split",
                    StreetName = "Marina Spinut",
                    PhoneNumber = "385665564689",
                };
                dbContext.BoatOwners.Add(boatOwner1);

                var userBoatOwner2 = new ApplicationUser() { Email = "boat.owner2@mail.com", UserName = "boat.owner2@mail.com", EmailConfirmed = true };
                var userBoatOwnerResult2 = userManager.CreateAsync(userBoatOwner2, "BoatOwner2*").Result;
                if (userBoatOwnerResult2.Succeeded)
                {
                    userManager.AddToRoleAsync(userBoatOwner2, "BoatOwner").Wait();
                }
                var boatOwner2 = new BoatOwner()
                {
                    ApplicationUser = userBoatOwner2,
                    Email = "boat.owner2@mail.com",
                    Name = "Petar",
                    Surname = "Peic",
                    County = "Croatia",
                    City = "Split",
                    StreetName = "Split",
                    PhoneNumber = "38555564689",
                };
                dbContext.BoatOwners.Add(boatOwner2);

                dbContext.SaveChanges();

                var boat11 = new Boat()
                {
                    Id = new Guid("f63ae92e-6203-42e8-9519-87c93fa5eab5"),
                    Name = "BENETEAU",
                    Type = "Cruiser",
                    NumberOfEngines = 0,
                    EnginePower = 5,
                    Address = new Address
                    {
                        County = "Croatia",
                        City = "Split",
                        Street = "Split",
                    },
                    Description = "Beneteau First 21.7 is the smallest sailing yacht available for charter in Split, Croatia. With her 1 cabin and 4 berths (two single and one double bed), she has ability to cater up to 4 people overnight. This makes this yacht a perfect choice for families or small groups of friends who wish to sail Central Adriatic area.",
                    Capacity = 6,
                    CancellationFee = 0.1f,
                    BoatOwner = boatOwner1,
                    BoatAdditionalOptions = new List<BoatAdditionalOptions>()
                {
                    new BoatAdditionalOptions()
                    {
                        Description = "Kayak",
                        Price = 80f,
                    },
                    new BoatAdditionalOptions()
                    {
                        Description = "Skipper",
                        Price = 150f,
                    },
                    new BoatAdditionalOptions()
                    {
                        Description = "Mobile toilet (WC)",
                        Price = 30f,
                    },
                },
                    Price = 350f

                };
                dbContext.Boats.Add(boat11);

                var boat21 = new Boat()
                {
                    Id = new Guid("66705287-b0b1-4ef2-ac6c-545de9bf1e01"),
                    Name = "JEANNEAU — MERRY FISHER 795",
                    Type = "Motorboat",
                    NumberOfEngines = 1,
                    EnginePower = 250,
                    Address = new Address
                    {
                        County = "Croatia",
                        City = "Split",
                        Street = "Split city center",
                    },
                    Description = "Welcome on our new Merry Fisher 795. The boat is from 2017. and it is refitted for this season. Capacity is up to 9 persons daily and 4-6 max overnight. The boat is fully equipped for 7 days charter with 220v supply, solar, kitchen, cockpit table, GPS, maps, toilette, and many other things.",
                    Capacity = 9,
                    CancellationFee = 0,
                    BoatOwner = boatOwner2,
                    BoatAdditionalOptions = new List<BoatAdditionalOptions>()
                {
                    new BoatAdditionalOptions()
                    {
                        Description = "Water skis",
                        Price = 25f,
                    },
                    new BoatAdditionalOptions()
                    {
                        Description = "Inflatable banana",
                        Price = 40f,
                    },
                },
                    Price = 300f
                };
                dbContext.Boats.Add(boat21);
                dbContext.SaveChanges();

                var boatAvailablePeriod111 = new BoatAvailablePeriod()
                {
                    Start = new DateTime(2022, 6, 4, 0, 0, 0),
                    End = new DateTime(2022, 6, 5, 0, 0, 0),
                    Boat = boat11,
                };
                dbContext.BoatAvailablePeriods.Add(boatAvailablePeriod111);

                var boatAvailablePeriod112 = new BoatAvailablePeriod()
                {
                    Start = new DateTime(2022, 9, 25, 0, 0, 0),
                    End = new DateTime(2022, 9, 30, 0, 0, 0),
                    Boat = boat11,
                };
                dbContext.BoatAvailablePeriods.Add(boatAvailablePeriod112);

                var boatAvailablePeriod113 = new BoatAvailablePeriod()
                {
                    Start = new DateTime(2022, 10, 1, 0, 0, 0),
                    End = new DateTime(2022, 10, 20, 0, 0, 0),
                    Boat = boat11,
                };
                dbContext.BoatAvailablePeriods.Add(boatAvailablePeriod113);

                var boatAvailablePeriod221 = new BoatAvailablePeriod()
                {
                    Start = new DateTime(2022, 9, 1, 0, 0, 0),
                    End = new DateTime(2022, 9, 12, 0, 0, 0),
                    Boat = boat21,
                };
                dbContext.BoatAvailablePeriods.Add(boatAvailablePeriod221);

                var boatAvailablePeriod222 = new BoatAvailablePeriod()
                {
                    Start = new DateTime(2022, 9, 17, 0, 0, 0),
                    End = new DateTime(2022, 9, 20, 0, 0, 0),
                    Boat = boat21,
                };
                dbContext.BoatAvailablePeriods.Add(boatAvailablePeriod222);
                dbContext.SaveChanges();
            }
            #endregion
            /*
            var userInstructor1 = new ApplicationUser() { Email = "instructor1@mail.com", UserName = "instructor11@mail.com", EmailConfirmed = true };
            var userInsturctorResult1 = userManager.CreateAsync(userInstructor1, "Instructor1*").Result;
            if (userInsturctorResult1.Succeeded)
            {
                userManager.AddToRoleAsync(userInstructor1, "Instructor").Wait();
            }
            var instructor1 = new Instructor()
            {
                ApplicationUser = userInstructor1,
                Email = "instructor1@mail.com",
                Name = "Djordje",
                Surname = "Lukic",
                County = "Serbia",
                City = "Novi Sad",
                StreetName = "Zeljeznicka 5",
                PhoneNumber = "3815656763",
            };
            dbContext.Instructors.Add(instructor1);

            dbContext.SaveChanges();

            var advLesson = new AdventureLesson()
            {
                Name
            }

            */

            if (!dbContext.SystemAdmins.Any())
            {
                var userSystemAdmin = new ApplicationUser() { Email = "systemAdmin@gmail.com", UserName = "systemAdmin@gmail.com", EmailConfirmed = true };
                var userSystemAdminResult = userManager.CreateAsync(userSystemAdmin, "SystemAdmin1*").Result;
                if (userSystemAdminResult.Succeeded)
                {
                    userManager.AddToRoleAsync(userSystemAdmin, "SystemAdmin").Wait();
                }
                var systemAdmin = new SystemAdmin()
                {
                    ApplicationUser = userSystemAdmin,
                    Email = "systemAdmin@gmail.com",
                    Name = "Admin",
                    Surname = "Admin",
                    County = "Serbia",
                    City = "Novi Sad",
                    StreetName = "Branka Bajica 9j",
                    PhoneNumber = "3815646763",
                    PasswordChanged = false,
                };
                dbContext.SystemAdmins.Add(systemAdmin);
                dbContext.SaveChanges();
            }

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
