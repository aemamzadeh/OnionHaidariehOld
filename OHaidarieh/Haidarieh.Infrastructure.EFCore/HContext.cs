using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.GuestAgg;
using Haidarieh.Domain.MemberAgg;
using Haidarieh.Domain.MultimediaAgg;
using Haidarieh.Domain.SponsorAgg;
using Haidarieh.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace Haidarieh.Infrastructure.EFCore
{
    public class HContext:DbContext
    {
        public DbSet<Ceremony> Ceremonies { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<CeremonyGuest> CeremonyGuests { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        public HContext(DbContextOptions<HContext> options): base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CeremonyGuestMapping());
            //modelBuilder.ApplyConfiguration(new CeremonyMapping());
            //modelBuilder.ApplyConfiguration(new GuestMapping());
            //modelBuilder.ApplyConfiguration(new MultimediaMapping());
            //modelBuilder.ApplyConfiguration(new MemberMapping());
            //modelBuilder.ApplyConfiguration(new SponsorMapping());
            var assembly = typeof(CeremonyMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
