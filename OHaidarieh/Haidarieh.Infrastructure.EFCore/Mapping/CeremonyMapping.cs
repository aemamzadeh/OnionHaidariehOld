using Haidarieh.Domain.CeremonyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Haidarieh.Infrastructure.EFCore.Mapping
{
    public class CeremonyMapping : IEntityTypeConfiguration<Ceremony>
    {
        public void Configure(EntityTypeBuilder<Ceremony> builder)
        {
            builder.ToTable("Tbl_Ceremony");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.CeremonyDate);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.CeremonyGuests).WithOne(x => x.Ceremony).HasForeignKey(x => x.CeremonyId);
            
        }
    }
}
