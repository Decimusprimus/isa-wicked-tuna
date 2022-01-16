using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WickedTunaCore.Auth;
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
            
            /*modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<SystemAdmin>().ToTable("SystemAdmins");
            modelBuilder.Entity<BoatOwner>().ToTable("BoatOwners");*/
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<SystemAdmin> SystemAdmins { get; set; }
        public DbSet<BoatOwner> BoatOwners { get; set; }
        //public DbSet<User> AppUsers { get; set; }
    }
}
