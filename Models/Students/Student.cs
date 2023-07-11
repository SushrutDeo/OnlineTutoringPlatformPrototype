using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.CodedLists;

namespace OnlineTutoringPlatformPrototype.Models.Students
{
	public class Student : EntityBase
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public int EducationLevelId { get; set; }

		public int GenderId { get; set; }

		public EducationLevel EducationLevel { get; set; }

		public Gender Gender { get; set; }

		public ICollection<Subject> Subjects { get; set; }
	}
}
