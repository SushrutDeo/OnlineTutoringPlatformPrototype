using OnlineTutoringPlatformPrototype.Enums;
using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.Students
{
	public class Student : EntityBase
	{
		public int UserId { get; set; }

		public string Address { get; set; }

		public EducationLevels EducationLevelId { get; set; }

		public Genders GenderId { get; set; }
	}
}
