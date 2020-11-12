using Haidarieh.Domain.MultimediaAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Haidarieh.Infrastructure.EFCore.Mapping
{
    public class MultimediaMapping:IEntityTypeConfiguration<Multimedia>
    {
        public void Configure(EntityTypeBuilder<Multimedia> builder)
        {
            builder.ToTable("Tbl_Multimedia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.FileAddress).IsRequired();
            builder.Property(x => x.FileTitle);
            builder.Property(x => x.FileAlt);
            builder.Property(x => x.CeremonyId).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Ceremony).WithMany(x => x.Multimedias).HasForeignKey(x => x.CeremonyId);
        }
    }
}
