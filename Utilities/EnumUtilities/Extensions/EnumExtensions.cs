using System.ComponentModel;
using System.Reflection;

namespace OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Extensions
{
	/// <summary>
	/// Class that hosts extension methods for the enum
	/// </summary>
	public static class EnumExtensions
	{
		#region Public Methods

		/// <summary>
		/// Return the [DescriptionAttribute] attribute value or the value if the description is not set
		/// </summary>
		public static string Description(this Enum enumValue)
		{
			if(enumValue == null)
			{
				return null;
			}

			Type type = enumValue.GetType();

			MemberInfo memberInfo = type.GetTypeInfo().DeclaredMembers.FirstOrDefault(x => x.Name == enumValue.ToString());

			DescriptionAttribute descriptionAtrribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();

			if(descriptionAtrribute == null || string.IsNullOrEmpty(descriptionAtrribute.Description))
			{
				return enumValue.ToString().Replace("_", " ");
			}

			return descriptionAtrribute.Description;
		}

		#endregion
	}
}
