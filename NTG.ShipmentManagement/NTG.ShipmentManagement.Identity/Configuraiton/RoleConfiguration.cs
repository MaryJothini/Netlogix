using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTG.ShipmentManagement.Identity.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "c08a4771-c0f7-4d19-b9ba-06ab215e5282",
                Name = "OrderCreator",
                NormalizedName = "ORDERCREATOR"
            },
            new IdentityRole
            {
                Id = "962ed809-195e-4413-945d-ac6f7baaca0c",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );
    }
}