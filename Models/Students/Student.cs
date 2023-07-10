using OnlineTutoringPlatformPrototype.Enums;
using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.CodedLists;

namespace OnlineTutoringPlatformPrototype.Models.Students
{
	public class Student : EntityBase
	{
		public int UserId { get; set; }

		public string Address { get; set; }

		public EducationLevels EducationLevelId { get; set; }

		public Genders GenderId { get; set; }

		public EducationLevel EducationLevel { get; set; }

		public Gender Gender { get; set; }

		public ICollection<Subject> Subjects { get; set; }
	}
}
