using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.OldMembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Repository;
using Unisol.Web.Portal.Services;

namespace Unisol.Web.Portal
{
	public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            //	.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			var oldMembershipConnection = DbSetting.ConnectionString(Configuration, "OldMembership");
			var membership = DbSetting.ConnectionString(Configuration, "Portal");
            var unisolDbConnection = DbSetting.ConnectionString(Configuration, "Unisol");
			services.AddMvc();
            services.AddDbContext<PortalCoreContext>(options => options.UseSqlServer(membership));
            services.AddDbContext<OldMembershipContext>(
                    options => options.UseSqlServer(oldMembershipConnection)
                    );
            services.AddDbContext<UnisolAPIdbContext>(options => options.UseSqlServer(unisolDbConnection)
                    );
            services.AddSingleton<IWeatherProvider, WeatherProviderFake>();
            services.AddSingleton<IUnisolApiProxy, UnisolApiProxy>();
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IPortalServices, PortalServices>();
			services.AddTransient<IUserManagementService, UserManagementService>();
			services.AddTransient<IAcademicsServices, AcademicsServices>();
			services.AddTransient<ICroneJobs, CroneJobs>();
			services.AddOptions();
			services.AddHangfire(x => x.UseSqlServerStorage(membership));
			//services.AddAuthentication(options =>
			//{
			//    options.DefaultAuthenticateScheme = CustomAuthOptions.DefaultScheme;
			//    options.DefaultChallengeScheme = CustomAuthOptions.DefaultScheme;
			//})
			//    // Call custom authentication extension method
			//    .AddCustomAuth(options =>
			//    {
			//        // Configure single or multiple passwords for authentication
			//        options.AuthKey = "custom auth key";
			//    });
		}

        //this method runs migrations automatically
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PortalCoreContext>();
                context.Database.Migrate();
                context.EnsureDatabaseSeeded();
                // context.Database.EnsureCreated();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = false,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Enable authentication capabilities
            app.UseAuthentication();

			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
            UpdateDatabase(app);
			app.UseHangfireServer();
			RecurringJob.AddOrUpdate<ICroneJobs>(h => h.ClearHostel(), Cron.MinuteInterval(10));
			//RecurringJob.AddOrUpdate<ICroneJobs>(h => h.PingPortals(), Cron.MinuteInterval(2));
		}
	}
}
