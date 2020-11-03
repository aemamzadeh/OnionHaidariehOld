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

            builder.OwnsMany(x => x.CeremonyOperations, modelBuilder =>
              {
                  modelBuilder.ToTable("Tbl_CeremonyOperation");
                  modelBuilder.HasKey(x => x.Id);
                  modelBuilder.Property(x => x.Description);
                  modelBuilder.Property(x => x.OperationDate);
                  modelBuilder.Property(x => x.OperatorId);
                  modelBuilder.Property(x => x.Operation);
                  modelBuilder.WithOwner(x => x.Ceremony).HasForeignKey(x => x.CeremonyId);
              });
            
        }
    }
}
