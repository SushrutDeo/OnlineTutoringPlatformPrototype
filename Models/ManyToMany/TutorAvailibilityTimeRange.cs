using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.ManyToMany
{
	public class TutorAvailibilityTimeRange : EntityBase
	{
		public int TutorId { get; set; }

		public int TimeRangeId { get; set; }
	}
}
