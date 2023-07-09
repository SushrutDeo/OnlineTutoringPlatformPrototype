using OnlineTutoringPlatformPrototype.Resources;

namespace OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Attributes
{
	/// <summary>
	/// Description attribute used for the enums
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DescriptionAttribute : Attribute
	{
		#region Public Constructor

		/// <summary>
		/// Public Constructor
		/// </summary>
		/// <param name="text"></param>
		public DescriptionAttribute(string text)
		{
			Text = Resource.ResourceManager.GetString(text);
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Text property of the attribute
		/// </summary>
		public string Text { get; private set; }

		#endregion
	}
}
