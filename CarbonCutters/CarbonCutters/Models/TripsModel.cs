using CarbonCuttersCore;

namespace CarbonCuttersView.Models
{
	public class TripsModel
	{
		public List<Trip> trips { get; set; }
		public int id { get; set; }
		public string date { get; set; }
		public List<string> startTime { get; set; }
		public List<string> endTime { get; set; }
		public List<string> vehicletype { get; set; }
		public List<string> size { get; set; }
		public List<string> fuel { get; set; }
		public List<int> distance { get; set; }
		public List<string> type1 { get; set; }
        public List<string> type2 { get; set; }
		public List<string> type3{ get; set; }
		public TripsModel()
		{

		}
	}
}
