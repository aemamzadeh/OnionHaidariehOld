using Haidarieh.Domain.GuestAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Haidarieh.Infrastructure.EFCore.Mapping
{
    public class GuestMapping : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Tbl_Guest");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.FullName);
            builder.Property(x => x.Tel);
            builder.Property(x => x.Email);
            builder.Property(x => x.Coordinator);
            builder.Property(x => x.GuestType);
            builder.Property(x => x.Image);
            builder.Property(x => x.ImageAlt);
            builder.Property(x => x.ImageTitle);

            builder.HasMany(x => x.CeremonyGuests).WithOne(x => x.Guest).HasForeignKey(x => x.GuestId);

        }
    }
}
