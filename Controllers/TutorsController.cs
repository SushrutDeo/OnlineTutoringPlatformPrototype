using Microsoft.AspNetCore.Mvc;

using OnlineTutoringPlatformPrototype.Dtos.RequestObjects;
using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TutorsController : ControllerBase
	{
		private readonly IGetTutorService _getTutorService;

		public TutorsController(IGetTutorService getTutorService)
		{
			_getTutorService = getTutorService;
		}

		[HttpGet("SearchTutors")]
		public async Task<ActionResult> SearchTutors([FromQuery] SearchDto searchDto)
		{
			var tutors = await _getTutorService.GetTutorsBySearchCriteriaAsync(searchDto);

			if(tutors.Any())
			{
				return Ok(tutors);
			}
			else
			{
				return NotFound();
			}
		}
	}
}
