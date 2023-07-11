using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.CodedLists;

namespace OnlineTutoringPlatformPrototype.Models.Tutors
{
	public class Tutor : EntityBase
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public decimal PricePerHour { get; set; }

		public int GenderId { get; set; }

		public Gender Gender { get; set; }

		public ICollection<TeachingPreference> TeachingPreferences { get; set; }

		public ICollection<WeekDay> WeekDays { get; set; }

		public ICollection<TimeRange> TimeRanges { get; set; }

		public ICollection<Subject> Subjects { get; set; }

		public ICollection<TutorAvailibility> TutorAvailibilities { get; set; }

		public ICollection<EducationLevel> EducationLevels { get; set; }
	}
}
