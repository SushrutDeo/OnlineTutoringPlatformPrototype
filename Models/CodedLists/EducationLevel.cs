using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.Students;
using OnlineTutoringPlatformPrototype.Models.Tutors;

namespace OnlineTutoringPlatformPrototype.Models.CodedLists
{
	public class EducationLevel : EntityBase
	{
		public string Name { get; set; }

		public ICollection<Tutor> Tutors { get; set; }

		public ICollection<Student> Students { get; set; }
	}
}
