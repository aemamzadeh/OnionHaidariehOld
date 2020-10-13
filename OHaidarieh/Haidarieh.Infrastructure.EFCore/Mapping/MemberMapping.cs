using Haidarieh.Domain.MemberAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Haidarieh.Infrastructure.EFCore.Mapping
{
    public class MemberMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Tbl_Member");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Mobile).IsRequired();
            builder.Property(x => x.Status);

            
        }
    }
}
