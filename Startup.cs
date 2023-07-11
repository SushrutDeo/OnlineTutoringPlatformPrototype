using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using OnlineTutoringPlatformPrototype.Data;
using OnlineTutoringPlatformPrototype.Data.Repositories.Implementation;
using OnlineTutoringPlatformPrototype.Data.Repositories.Interfaces;
using OnlineTutoringPlatformPrototype.Services.Implementation;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype
{
	public class Startup
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			Configuration = configuration;
			_webHostEnvironment = webHostEnvironment;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var connectionString = Configuration.GetConnectionString("OTPConnection");

			services.AddDbContext<OTPDbContext>(opt => opt.UseSqlServer(connectionString));

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddScoped<IGetTutorService, GetTutorService>();

			services.AddScoped<IGetSubjectService, GetSubjectService>();

			services.AddScoped<IConvertEnumsToIntStringPair, ConvertEnumsToIntStringPair>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "OTP",
					Description = "OTP API",
				});
			});

			services.Configure<IConfiguration>(Configuration);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "OTP");
			});
		}

	}
}
