using OnlineTutoringPlatformPrototype.Dtos.BasicObjects;

namespace OnlineTutoringPlatformPrototype.Services.Interfaces
{
	public interface IConvertEnumsToIntStringPair
	{
		/// <summary>
		/// Converts an enum text and corresponding value to int string pair
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		List<IntStringPair> ConvertEnumToIntStringPair<T>() where T : Enum;
	}
}
