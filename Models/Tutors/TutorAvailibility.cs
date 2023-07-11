using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.CodedLists;

namespace OnlineTutoringPlatformPrototype.Models.Tutors
{
	public class TutorAvailibility : EntityBase
	{
		public int TutorId { get; set; }

		public int WeekDayId { get; set; }

		public int TimeRangeId { get; set; }

		public Tutor Tutor { get; set; }

		public WeekDay WeekDay { get; set; }

		public TimeRange TimeRange { get; set; }
	}
}
