using OnlineTutoringPlatformPrototype.Dtos.ResponseObjects;

namespace OnlineTutoringPlatformPrototype.Services.Interfaces
{
	public interface IGetSubjectService
	{
		Task<ICollection<SubjectDto>> GetAllSubjectsAsync();
	}
}
