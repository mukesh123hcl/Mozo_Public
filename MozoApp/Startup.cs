using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MozoApp.Data;
using MozoDataAccess.Data;
using MozoDataAccess.Repository;
using MozoModels.Models;
using MozoUtilty.Utility;
namespace MozoApp
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
			
			services.AddControllersWithViews();
			services.AddMvc();
			services.AddDistributedMemoryCache();

			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(10);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			services.AddDbContext<Mozo_Data_Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IServiceRepository<>), typeof(Service_Rpository<>));
		
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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSession();
	
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapControllerRoute(
					name: "Admin",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute(
					name: "Booking",
					pattern: "{area:exists}/{controller=Booking}/{action=Index}/{id?}");
				endpoints.MapControllerRoute(
					name: "User_Profile",
					pattern: "{area:exists}/{controller=Profile}/{action=Profile}/{id?}");
				endpoints.MapControllerRoute(
					name: "User_Profile",
					pattern: "{area:exists}/{controller=Profile}/{action=Personal}/{id?}");
				endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
