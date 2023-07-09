using OnlineTutoringPlatformPrototype.Models.BaseClasses;

using System.ComponentModel.DataAnnotations;

namespace OnlineTutoringPlatformPrototype.Models.Users
{
	public class User : EntityBase
	{
		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[EmailAddress]
		public string EmailAddress { get; set; }

		public string Password { get; set; }
	}
}
