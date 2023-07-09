using OnlineTutoringPlatformPrototype.Enums;
using OnlineTutoringPlatformPrototype.Models.BaseClasses;

namespace OnlineTutoringPlatformPrototype.Models.Tutors
{
	public class Tutor : EntityBase
	{
		public int UserId { get; set; }

		public string Address { get; set; }

		public Genders GenderId { get; set; }
	}
}
