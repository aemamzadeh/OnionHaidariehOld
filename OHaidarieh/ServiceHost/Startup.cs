using _0_Framework.Application;
using AccountManagement.Configuration;
using Haidarieh.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;
using _0_Framework.Infrastructure;
using _0_Framework.Application.Email;
using _0_Framework.Application.Sms;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();

            var connectionString = Configuration.GetConnectionString("OHaidariehDb");
            HaidariehBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddKendo();



            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> { Roles.Admin, Roles.Engineer }));
                options.AddPolicy("Ceremony",
                    builder => builder.RequireRole(new List<string> { Roles.Admin, Roles.Engineer }));
                options.AddPolicy("UserMng",
                    builder => builder.RequireRole(new List<string> { Roles.Admin }));

            });

            services.AddRazorPages()
                    .AddMvcOptions(options=>options.Filters.Add<SecurityPageFilter>())
                    .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Ceremonies", "Ceremony");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Accounts", "UserMng");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Roles", "UserMng");



            });
            //services.AddRazorPages();

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseCookiePolicy();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });
    }
}
}
