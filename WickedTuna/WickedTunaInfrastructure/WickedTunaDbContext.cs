using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure
{
    public class WickedTunaDbContext : DbContext
    {
        public WickedTunaDbContext(DbContextOptions<WickedTunaDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
