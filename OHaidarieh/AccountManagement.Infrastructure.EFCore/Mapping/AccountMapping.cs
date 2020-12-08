using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Tbl_Accounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Fname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Lname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(20).IsRequired();
            builder.Property(x => x.ProfilePhoto).HasMaxLength(1000);
            builder.Property(x => x.Username).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
            //builder.Property(x => x.RoleId);

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);
        }
    }
}
