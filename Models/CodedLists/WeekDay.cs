using OnlineTutoringPlatformPrototype.Models.BaseClasses;
using OnlineTutoringPlatformPrototype.Models.Tutors;

namespace OnlineTutoringPlatformPrototype.Models.CodedLists
{
	public class WeekDay : EntityBase
	{
		public string Name { get; set; }

		public ICollection<Tutor> Tutors { get; set; }
	}
}
