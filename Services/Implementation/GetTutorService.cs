using LinqKit;

using OnlineTutoringPlatformPrototype.Data.Repositories.Interfaces;
using OnlineTutoringPlatformPrototype.Dtos.RequestObjects;
using OnlineTutoringPlatformPrototype.Dtos.ResponseObjects;
using OnlineTutoringPlatformPrototype.Models.Tutors;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

using System.Linq.Expressions;

namespace OnlineTutoringPlatformPrototype.Services.Implementation
{
	public class GetTutorService : IGetTutorService
	{
		private readonly IRepository<Tutor> _repository;

		public GetTutorService(IRepository<Tutor> repository)
		{
			_repository = repository;
		}

		public async Task<ICollection<TutorDto>> GetTutorsBySearchCriteriaAsync(SearchDto searchDto)
		{
			var filter = PredicateBuilder.New<Tutor>();

			filter.And(t => t.IsDeleted == false);

			if(!string.IsNullOrWhiteSpace(searchDto.City))
			{
				filter.And(t => t.City == searchDto.City);
			}

			if(searchDto.SubjectId.HasValue)
			{
				filter.And(t => t.Subjects.Any(s => s.Id == searchDto.SubjectId.Value));
			}

			if(searchDto.GenderId.HasValue)
			{
				filter.And(t => t.GenderId == searchDto.GenderId.Value);
			}

			if(searchDto.MinPrice.HasValue)
			{
				filter.And(t => t.PricePerHour >= searchDto.MinPrice.Value);
			}

			if(searchDto.MaxPrice.HasValue)
			{
				filter.And(t => t.PricePerHour <= searchDto.MaxPrice.Value);
			}

			if(searchDto.AvailableDays.Any())
			{
				foreach(var day in searchDto.AvailableDays)
				{
					filter.And(t => t.TutorAvailibilities.Any(ta => ta.WeekDayId == day));
				}
			}

			if(searchDto.TeachingPreferenceIds.Any())
			{
				foreach(var tpId in searchDto.TeachingPreferenceIds)
				{
					filter.And(t => t.TeachingPreferences.Any(tp => tp.Id == tpId));
				}
			}

			if(searchDto.LevelId.HasValue)
			{
				filter.And(t => t.EducationLevels.Any(el => el.Id == searchDto.LevelId));
			}

			Expression<Func<Tutor, object>>[] includes = { t => t.Subjects, t => t.WeekDays,
				t => t.EducationLevels, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutors = await _repository.GetAllAsync(filter, includes);

			var tutorDtos = tutors.Select(t => new TutorDto
			{
				HourlyRate = t.PricePerHour,
				Name = $"{t.FirstName} {t.LastName}",

			}).ToList();

			return tutorDtos;
		}
	}
}
