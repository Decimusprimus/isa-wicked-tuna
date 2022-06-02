using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.Auth;

namespace WickedTunaInfrastructure.Configurations
{
    public class RefreshTokensConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasOne<ApplicationUser>(u => u.User)
                .WithMany(r => r.RefreshTokens)
                .HasForeignKey(u => u.UserId);

        }
    }
}
