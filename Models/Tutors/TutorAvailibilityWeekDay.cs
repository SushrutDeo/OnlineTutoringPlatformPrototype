using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.Tutors
{
	public class TutorAvailibilityWeekDay : EntityBase
	{
		public int TutorId { get; set; }

		public DayOfWeek DayOfWeekId { get; set; }
	}
}
