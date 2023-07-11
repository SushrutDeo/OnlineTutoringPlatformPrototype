using Microsoft.AspNetCore.Mvc;

using OnlineTutoringPlatformPrototype.Services.Interfaces;

namespace OnlineTutoringPlatformPrototype.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SubjectsController : ControllerBase
	{
		private readonly IGetSubjectService _getSubjectService;

		public SubjectsController(IGetSubjectService getSubjectService)
		{
			_getSubjectService = getSubjectService;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var subjects = await _getSubjectService.GetAllSubjectsAsync();

			if(subjects.Any())
			{
				return Ok(subjects);
			}
			else
			{
				return NotFound();
			}
		}
	}
}
