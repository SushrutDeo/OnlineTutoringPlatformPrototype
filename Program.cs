
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using OnlineTutoringPlatformPrototype.Data;

namespace OnlineTutoringPlatformPrototype
{
	public class Program
	{
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using(IServiceScope serviceScope = host.Services.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<OTPDbContext>();

				try
				{
					context.Database.Migrate();
				}
				catch(SqlException)
				{
					// Exception is expected if Nonacus.Api runs first and migrates the database. Nothing we can do about it. Just catch the exception and carry on.
				}
			}

			host.Run();

			//var builder = WebApplication.CreateBuilder(args);

			//var connectionString = builder.Configuration.GetConnectionString("OnlineTutoringPlatform");

			//// Add services to the container.

			//builder.Services.AddControllersWithViews();

			//builder.Services.AddDbContext<OTPDbContext>(opt => opt.UseSqlServer(connectionString));

			//var app = builder.Build();

			//// Configure the HTTP request pipeline.
			//if(!app.Environment.IsDevelopment())
			//{
			//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			//	app.UseHsts();
			//}

			//app.UseHttpsRedirection();
			//app.UseStaticFiles();
			//app.UseRouting();


			//app.MapControllerRoute(
			//	name: "default",
			//	pattern: "{controller}/{action=Index}/{id?}");

			//app.MapFallbackToFile("index.html");

			//app.Run();
		}
	}
}