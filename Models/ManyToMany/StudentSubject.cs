using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.ManyToMany
{
	public class StudentSubject : EntityBase
	{
		public int StudentId { get; set; }

		public int SubjectId { get; set; }
	}
}
