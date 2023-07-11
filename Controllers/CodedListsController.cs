using Microsoft.AspNetCore.Mvc;

using OnlineTutoringPlatformPrototype.Dtos.BasicObjects;
using OnlineTutoringPlatformPrototype.Enums;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CodedListsController : ControllerBase
	{
		private readonly IConvertEnumsToIntStringPair _convertEnumsToIntStringPair;

		public CodedListsController(IConvertEnumsToIntStringPair convertEnumsToIntStringPair)
		{
			_convertEnumsToIntStringPair = convertEnumsToIntStringPair;
		}

		[HttpGet("EducationLevels")]
		public ActionResult<List<IntStringPair>> GetEducationLevels()
		{
			var educationLevels = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<EducationLevels>();

			return Ok(educationLevels);
		}

		[HttpGet("Genders")]
		public ActionResult<List<IntStringPair>> GetGenders()
		{
			var genders = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<Genders>();

			return Ok(genders);
		}

		[HttpGet("TeachingPreferences")]
		public ActionResult<List<IntStringPair>> GetTeachingPreferences()
		{
			var teachingPreferences = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<TeachingPreferences>();

			return Ok(teachingPreferences);
		}

		[HttpGet("TimeRanges")]
		public ActionResult<List<IntStringPair>> GetTimeRanges()
		{
			var timeRanges = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<TimeRanges>();

			return Ok(timeRanges);
		}

		[HttpGet("WeekDays")]
		public ActionResult<List<IntStringPair>> GetWeekDays()
		{
			var weekDays = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<DayOfWeek>();

			// DayOfWeek enum values starts with 0 but we cannot have 0 as a key in the database.
			// Hence add one to the 'Key' value
			weekDays.ForEach(weekDay => weekDay.Key += 1);

			return Ok(weekDays);
		}
	}
}
