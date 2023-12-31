﻿using OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Attributes;

namespace OnlineTutoringPlatformPrototype.Enums
{
	/// <summary>
	/// Enum representing eduction levels
	/// </summary>
	public enum EducationLevels
	{
		Primary = 1,

		Secondary = 2,

		GCSE = 3,

		[Description("A_Level")]
		A_Level = 4,

		University = 5,

		Masters = 6,
	}
}
