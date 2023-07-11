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
			builder.ToTable(nameof(Student));

			builder.HasMany(s => s.Subjects)
				.WithMany(s => s.Students)
				.UsingEntity<StudentSubject>();
		}
	}
}
