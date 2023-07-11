using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineTutoringPlatformPrototype.Models.ManyToMany;
using OnlineTutoringPlatformPrototype.Models.Tutors;

namespace OnlineTutoringPlatformPrototype.Configuration
{
	public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
	{
		public void Configure(EntityTypeBuilder<Tutor> builder)
		{
			builder.HasMany(t => t.Subjects)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorSubject>();

			builder.HasMany(t => t.TeachingPreferences)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorTeachingPreference>();

			builder.HasMany(t => t.WeekDays)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorAvailibilityWeekDay>();

			builder.HasMany(t => t.TimeRanges)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorAvailibilityTimeRange>();
		}
	}
}
