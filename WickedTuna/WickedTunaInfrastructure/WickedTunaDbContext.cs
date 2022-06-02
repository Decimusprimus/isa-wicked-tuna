using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WickedTunaCore.AdventuresLessons;
using WickedTunaCore.Auth;
using WickedTunaCore.Boats;
using WickedTunaCore.Cottages;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure
{
    public class WickedTunaDbContext : IdentityDbContext<ApplicationUser>
    {
        public WickedTunaDbContext(DbContextOptions<WickedTunaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<SystemAdmin> SystemAdmins { get; set; }
        public DbSet<BoatOwner> BoatOwners { get; set; }
        public DbSet<CottageOwner> CottageOwners{ get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Cottage> Cottages { get; set; }
        public DbSet<CottageReservation> CottageReservations { get; set; }
        public DbSet<CottageAvailablePeriod> CottageAvailablePeriods { get; set; }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<AdventureLesson> AdventrueLessons { get; set; }
    }
}
