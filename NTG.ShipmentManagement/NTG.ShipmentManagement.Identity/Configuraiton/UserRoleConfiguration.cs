using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTG.ShipmentManagement.Identity.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "962ed809-195e-4413-945d-ac6f7baaca0c",
                UserId = "018d5533-6a11-40f1-8959-f32fdf0c8a1b"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c08a4771-c0f7-4d19-b9ba-06ab215e5282",
                UserId = "018d5533-6a11-40f1-8959-f32fdf0c8a1b"
            },
             new IdentityUserRole<string>
             {
                 RoleId = "c08a4771-c0f7-4d19-b9ba-06ab215e5282",
                 UserId = "6ad3a85a-52bd-4911-9038-200ac69b25ea"
             }
        );
    }
}