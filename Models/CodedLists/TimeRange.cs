using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.Tutors;

namespace OnlineTutoringPlatformPrototype.Models.CodedLists
{
	public class TimeRange : EntityBase
	{
		public string Name { get; set; }

		public ICollection<Tutor> Tutors { get; set; }
	}
}
