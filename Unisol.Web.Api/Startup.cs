using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.Repository;
using Unisol.Web.Api.Services;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.LibraryModels;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				// .AddJsonFile($"appsettings.{env.EnvironmentName}.json")

				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//var constring = $"Server=197.232.37.106;Database=unisoluoemdb;User Id=portal;password=p0t@l2.14;";
			var unisolDbConnection = DbSetting.ConnectionString(Configuration, "Unisol");
			var libraryDbConnection = DbSetting.ConnectionString(Configuration, "Library");

			services.AddMvc();
			services.AddSingleton<IPortalApiProxy, PortalApiProxy>();
			services.AddTransient<IStudentServices, StudentServices>();
			services.AddTransient<IStaffServices, StaffServices>();
			services.AddTransient<ISystemServices, SystemServices>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddDbContext<UnisolAPIdbContext>(options => options.UseSqlServer(unisolDbConnection));
			services.AddDbContext<LibraryAPIdbContext>(options => options.UseMySQL(libraryDbConnection));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}

