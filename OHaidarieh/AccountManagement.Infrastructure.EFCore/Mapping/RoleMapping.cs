using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Tbl_Roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("Tbl_RolePermission");
                navigationBuilder.WithOwner(x=>x.Role);
                navigationBuilder.Ignore(x => x.Name);
            });
        }
    }
}
