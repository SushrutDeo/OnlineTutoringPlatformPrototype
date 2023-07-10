using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.ManyToMany
{
	public class TutorSubject : EntityBase
	{
		public int TutorId { get; set; }

		public int SubjectId { get; set; }
	}
}
