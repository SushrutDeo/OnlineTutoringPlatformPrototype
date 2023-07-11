namespace OnlineTutoringPlatformPrototype.Dtos.RequestObjects
{
	public class SearchDto
	{
		public string City { get; set; }

		public List<int> TeachingPreferenceIds { get; set; }

		public int? SubjectId { get; set; }

		public int? LevelId { get; set; }

		public List<int> AvailableDays { get; set; }

		public decimal? MinPrice { get; set; }

		public decimal? MaxPrice { get; set; }

		public int? GenderId { get; set; }
	}
}
