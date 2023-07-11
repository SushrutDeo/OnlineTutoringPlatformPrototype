using Microsoft.EntityFrameworkCore;

using OnlineTutoringPlatformPrototype.Models.CodedLists;
using OnlineTutoringPlatformPrototype.Models.ManyToMany;
using OnlineTutoringPlatformPrototype.Models.Roles;
using OnlineTutoringPlatformPrototype.Models.Students;
using OnlineTutoringPlatformPrototype.Models.Tutors;
using OnlineTutoringPlatformPrototype.Models.Users;

using System.Reflection;

namespace OnlineTutoringPlatformPrototype.Data
{
	public class OTPDbContext : DbContext
	{
		public OTPDbContext(DbContextOptions<OTPDbContext> options) : base(options)
		{

		}

		public DbSet<EducationLevel> EducationLevels { get; set; }

		public DbSet<Gender> Genders { get; set; }

		public DbSet<Subject> Subjects { get; set; }

		public DbSet<TeachingPreference> TeachingPreferences { get; set; }

		public DbSet<TimeRange> TimeRanges { get; set; }

		public DbSet<WeekDay> WeekDays { get; set; }

		public DbSet<StudentSubject> StudentSubjects { get; set; }

		public DbSet<TutorAvailibilityTimeRange> TutorAvailibilityTimeRanges { get; set; }

		public DbSet<TutorAvailibilityWeekDay> TutorAvailibilityWeekDays { get; set; }

		public DbSet<TutorSubject> TutorSubjects { get; set; }

		public DbSet<TutorTeachingPreference> TutorTeachingPreferences { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Tutor> Tutors { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EducationLevel>().ToTable(nameof(EducationLevel));

			modelBuilder.Entity<Gender>().ToTable(nameof(Gender));

			modelBuilder.Entity<Subject>().ToTable(nameof(Subject));

			modelBuilder.Entity<TeachingPreference>().ToTable(nameof(TeachingPreference));

			modelBuilder.Entity<TimeRange>().ToTable(nameof(TimeRange));

			modelBuilder.Entity<WeekDay>().ToTable(nameof(WeekDay));

			modelBuilder.Entity<StudentSubject>().ToTable(nameof(StudentSubject));

			modelBuilder.Entity<TutorAvailibilityTimeRange>().ToTable(nameof(TutorAvailibilityTimeRange));

			modelBuilder.Entity<TutorAvailibilityWeekDay>().ToTable(nameof(TutorAvailibilityWeekDay));

			modelBuilder.Entity<TutorSubject>().ToTable(nameof(TutorSubject));

			modelBuilder.Entity<TutorTeachingPreference>().ToTable(nameof(TutorTeachingPreference));

			modelBuilder.Entity<Role>().ToTable(nameof(Role));

			modelBuilder.Entity<Student>().ToTable(nameof(Student));

			modelBuilder.Entity<Tutor>().ToTable(nameof(Tutor));

			modelBuilder.Entity<User>().ToTable(nameof(User) + "s");

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
