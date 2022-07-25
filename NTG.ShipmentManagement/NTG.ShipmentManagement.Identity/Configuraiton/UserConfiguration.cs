using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTG.ShipmentManagement.Identity.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        var haser = new PasswordHasher<IdentityUser>();
        builder.HasData(
            new IdentityUser
            {
                Id = "018d5533-6a11-40f1-8959-f32fdf0c8a1b",
                Email = "admin@ngt-shipper.com",
                NormalizedEmail = "ADMIN@NGT-SHIPPER.COM",
                UserName = "admin@ngt-shipper.com",
                NormalizedUserName = "ADMIN@NGT-SHIPPER.COM",
                PasswordHash = haser.HashPassword(null, "password"),
                EmailConfirmed = true
            },
            new IdentityUser
            {
                Id = "6ad3a85a-52bd-4911-9038-200ac69b25ea",
                Email = "user@ngt-shipper.com",
                NormalizedEmail = "USER@NGT-SHIPPER.COM",
                UserName = "user@ngt-shipper.com",
                NormalizedUserName = "USER@NGT-SHIPPER.COM",
                PasswordHash = haser.HashPassword(null, "password"),
                EmailConfirmed = true
            }
        );
    }
}