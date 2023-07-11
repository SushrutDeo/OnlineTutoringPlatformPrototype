using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.ManyToMany
{
	public class TutorAvailibilityWeekDay : EntityBase
	{
		public int TutorId { get; set; }

		public int WeekDayId { get; set; }
	}
}
