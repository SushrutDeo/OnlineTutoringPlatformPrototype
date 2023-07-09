using OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Attributes;

namespace OnlineTutoringPlatformPrototype.Enums
{
	public enum TeachingLocations
	{
		Online = 1,

		[Description("Student_Home")]
		Student_Home = 2,

		[Description("Tutor_Home")]
		Tutor_Home = 3,
	}
}
