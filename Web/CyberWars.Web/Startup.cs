namespace CyberWars.Web
{
    using System.Reflection;

    using CyberWars.Data;
    using CyberWars.Data.Common;
    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Repositories;
    using CyberWars.Data.Seeding;
    using CyberWars.Services.Data;
    using CyberWars.Services.Data.Academy;
    using CyberWars.Services.Data.CompetitiveCoding;
    using CyberWars.Services.Data.DarkWeb;
    using CyberWars.Services.Data.Home;
    using CyberWars.Services.Data.Market;
    using CyberWars.Services.Data.Team;
    using CyberWars.Services.Data.Web;
    using CyberWars.Services.Mapping;
    using CyberWars.Services.Messaging;
    using CyberWars.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Hangfire;
    using Hangfire.SqlServer;
    using System;
    using CyberWars.Web.ViewModels.WebViews.Job;
    using System.Threading.Tasks;
    using Hangfire.Dashboard;
    using CyberWars.Common;
    using CyberWars.Services.Data.Hangfire;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/Login";
            });
            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();

            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient<IWebService, WebService>();
            services.AddTransient<IDarkWebService, DarkWebService>();
            services.AddTransient<IContestService, ContestService>();
            services.AddTransient<IAcademyService, AcademyService>();
            services.AddTransient<ITeamService, TeamService>();

            services.AddHangfire(config =>
            {
                // ReferenceLoop Fixing json error for resetStats on the player
                config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSqlServerStorage(
                this.configuration.GetConnectionString("DefaultConnection"),
                new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true,
                });
            });
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJob)
        {

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();

                this.SeedHangfireJobs(recurringJob);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });


        }

        public async Task SeedHangfireJobs(IRecurringJobManager recurringJob)
        {
            recurringJob.AddOrUpdate<PetStatsService>("PetStatsService", x => x.PetStatsDownEveryHour(), Cron.Hourly);
            recurringJob.AddOrUpdate<UpdatePetFavouriteFoodService>("UpdatePetFavouriteFoodService", x => x.ChangePetFavouriteFoodEveryDay(), Cron.Daily);
            recurringJob.AddOrUpdate<AddJobService>("AddJobService", x => x.UpdateRandomJobs(), Cron.Daily);
            recurringJob.AddOrUpdate<UpdateContests>("UpdateContests", x => x.UpdateRandomContests(), Cron.Daily);
        }

    }
}
