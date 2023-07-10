using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace OnlineTutoringPlatformPrototype.Data
{
	public class OTPDbContext : DbContext
	{
		public OTPDbContext(DbContextOptions<OTPDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
