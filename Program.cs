using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using OnlineTutoringPlatformPrototype.Data;
using OnlineTutoringPlatformPrototype.Data.Repositories.Implementation;
using OnlineTutoringPlatformPrototype.Data.Repositories.Interfaces;
using OnlineTutoringPlatformPrototype.Services.Implementation;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype
{
	public class Program
	{
		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args)
		//		.ConfigureWebHostDefaults(webBuilder =>
		//		{
		//			webBuilder.UseStartup<Startup>();
		//		});

		public static void Main(string[] args)
		{
			//var host = CreateHostBuilder(args).Build();

			//using(IServiceScope serviceScope = host.Services.CreateScope())
			//{
			//	var context = serviceScope.ServiceProvider.GetRequiredService<OTPDbContext>();

			//	try
			//	{
			//		context.Database.Migrate();
			//	}
			//	catch(SqlException)
			//	{
			//		// Exception is expected if Nonacus.Api runs first and migrates the database. Nothing we can do about it. Just catch the exception and carry on.
			//	}
			//}

			//host.Run();

			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("OnlineTutoringPlatform");

			// Add services to the container.

			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<OTPDbContext>(opt => opt.UseSqlServer(connectionString));

			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			builder.Services.AddScoped<IGetTutorService, GetTutorService>();

			builder.Services.AddScoped<IGetSubjectService, GetSubjectService>();

			builder.Services.AddScoped<IConvertEnumsToIntStringPair, ConvertEnumsToIntStringPair>();

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "OTP",
					Description = "OTP API",
				});
			});

			builder.Services.Configure<IConfiguration>(builder.Configuration);

			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if(!app.Environment.IsDevelopment())
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();


			app.MapControllerRoute(
				name: "default",
				pattern: "{controller}/{action=Index}/{id?}");

			app.MapFallbackToFile("index.html");

			app.Run();
		}
	}
}