using CarbonCuttersCore;

namespace CarbonCuttersView.Models
{
	public class TripsModel
	{
		public List<Trip> trips { get; set; }
		public DateOnly date { get; set; }
		public TimeOnly startTime { get; set; }
		public TimeOnly endTime { get; set; }
		public string vehicletype { get; set; }
		public string size { get; set; }
		public string fuel { get; set; }
		public int distance { get; set; }
		public string type { get; set; }
		public TripsModel()
		{

		}
	}
}
