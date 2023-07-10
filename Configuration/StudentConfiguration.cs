using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineTutoringPlatformPrototype.Models.ManyToMany;
using OnlineTutoringPlatformPrototype.Models.Students;

namespace OnlineTutoringPlatformPrototype.Configuration
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasMany(t => t.Subjects)
				.WithMany(t => t.Students)
				.UsingEntity<StudentSubject>();
		}
	}
}
