using LinqKit;

using OnlineTutoringPlatformPrototype.Data.Repositories.Interfaces;
using OnlineTutoringPlatformPrototype.Dtos.ResponseObjects;
using OnlineTutoringPlatformPrototype.Models.CodedLists;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype.Services.Implementation
{
	public class GetSubjectService : IGetSubjectService
	{
		private readonly IRepository<Subject> _repository;

		public GetSubjectService(IRepository<Subject> repository)
		{
			_repository = repository;
		}

		public async Task<ICollection<SubjectDto>> GetAllSubjectsAsync()
		{
			var filter = PredicateBuilder.New<Subject>();

			filter.And(t => t.IsDeleted == false);

			var subjects = await _repository.GetAllAsync(filter);

			var subjectDtos = subjects.Select(s => new SubjectDto
			{
				SubjectId = s.Id,
				SubjectName = s.Name,
			});

			return subjectDtos.ToList();
		}
	}
}
