using OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Attributes;

namespace OnlineTutoringPlatformPrototype.Enums
{
	public enum TeachingPreferences
	{
		Online = 1,

		[Description("Student's_Home")]
		Student_Home = 2,

		[Description("Tutor's_Home")]
		Tutor_Home = 3,
	}
}
