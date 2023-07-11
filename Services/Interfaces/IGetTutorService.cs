using OnlineTutoringPlatformPrototype.Dtos.RequestObjects;
using OnlineTutoringPlatformPrototype.Dtos.ResponseObjects;

namespace OnlineTutoringPlatformPrototype.Services.Interfaces
{
	public interface IGetTutorService
	{
		Task<ICollection<TutorDto>> GetTutorsBySearchCriteriaAsync(SearchDto searchDto);
	}
}
