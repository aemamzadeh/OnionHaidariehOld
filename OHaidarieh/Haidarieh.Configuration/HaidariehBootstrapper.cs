using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Guests;
using _01_HaidariehQuery.Contracts.Members;
using _01_HaidariehQuery.Contracts.Multimedias;
using _01_HaidariehQuery.Contracts.Sponsers;
using _01_HaidariehQuery.Query;
using Haidarieh.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Application.Contracts.Member;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Application.Contracts.Sponsor;
using Haidarieh.Configuration.Permissions;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.GuestAgg;
using Haidarieh.Domain.MemberAgg;
using Haidarieh.Domain.MultimediaAgg;
using Haidarieh.Domain.SponsorAgg;
using Haidarieh.Infrastructure.EFCore;
using Haidarieh.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Haidarieh.Configuration
{
    public class HaidariehBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICeremonyApplication, CeremonyApplication>();
            services.AddTransient<ICeremonyRepository, CeremonyRepository>();
            
            services.AddTransient<ICeremonyGuestApplication, CeremonyGuestApplication>();
            services.AddTransient<ICeremonyGuestRepository, CeremonyGuestRepository>();
            
            services.AddTransient<IGuestApplication, GuestApplication>();
            services.AddTransient<IGuestRepository, GuestRepository>();
            
            services.AddTransient<IMemberApplication, MemberApplication>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            
            services.AddTransient<ISponsorApplication, SponsorApplication>();
            services.AddTransient<ISponsorRepository, SponsorRepository>();
            
            services.AddTransient<IMultimediaApplication, MultimediaApplication>();
            services.AddTransient<IMultimediaRepository, MultimediaRepository>();

            services.AddTransient<ICeremonyGuestQuery, CeremonyGuestQuery>();
            services.AddTransient<ICeremonyQuery, CeremonyQuery>();
            services.AddTransient<IGuestQuery, GuestQuery>();
            services.AddTransient<IMemberQuery, MemberQuery>();
            services.AddTransient<IMultimediaQuery, MultimediaQuery>();
            services.AddTransient<ISponsorQuery, SponsorQuery>();

            services.AddTransient<IPermissionExposer, HPermissionExposer>();

            services.AddDbContext<HContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
