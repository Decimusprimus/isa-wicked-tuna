using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<Client> Clients { get; set; }
    }
}
