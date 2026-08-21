using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class ApplicationUserConfiguration
    : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(
        EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}