using OnlineTutoringPlatformPrototype.Dtos.BasicObjects;
using OnlineTutoringPlatformPrototype.Services.Interfaces;
using OnlineTutoringPlatformPrototype.Utilities.EnumUtilities.Attributes;

using System.Reflection;

namespace OnlineTutoringPlatformPrototype.Services.Implementation
{
	public class ConvertEnumsToIntStringPair : IConvertEnumsToIntStringPair
	{
		#region Public Methods

		/// <summary>
		/// Converts an enum text and corresponding value to int string pair
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public List<IntStringPair> ConvertEnumToIntStringPair<T>() where T : Enum
		{
			Type type = typeof(T);

			Array enumValues = Enum.GetValues(type);

			List<IntStringPair> intStringPairs = new();

			foreach(var enumValue in enumValues)
			{
				int key = (int)Enum.Parse(typeof(T), enumValue.ToString());

				MemberInfo memberInfo = type.GetTypeInfo().DeclaredMembers.FirstOrDefault(x => x.Name == enumValue.ToString());

				DescriptionAttribute attribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();

				string value = attribute == null ? enumValue.ToString().Replace("_", " ") : attribute.Text;

				if(!value.Equals("Undefined"))
				{
					IntStringPair intStringPair = new(key, value);

					intStringPairs.Add(intStringPair);
				}
			}

			return intStringPairs;
		}

		#endregion
	}
}
