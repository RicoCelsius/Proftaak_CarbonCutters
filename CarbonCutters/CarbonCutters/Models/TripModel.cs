using CarbonCuttersCore.Interface;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
        public IUserCollection userCollection;

        public int id { get; set; }
        public List<int> distance { get; set; }
        public List<string> vehicletype { get; set; }
        public List<DateOnly> date { get; set; }
        public List<TimeOnly> startTime { get; set; }
        public List<TimeOnly> endTime { get; set; }

        public List<string> type1 { get; set; }
        public List<string> type2 { get; set; }
        public List<string> size { get; set; }
        public List<string> fuel { get; set; }
        public TripModel()
        {
            
        }
    }
}
