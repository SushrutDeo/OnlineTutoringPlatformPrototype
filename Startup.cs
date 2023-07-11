using Microsoft.EntityFrameworkCore;

using OnlineTutoringPlatformPrototype.Data;

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

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "OTP");
			});
		}

	}
}
