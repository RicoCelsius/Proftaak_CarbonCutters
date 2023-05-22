using CarbonCuttersCore.Interface;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
        public IUserCollection userCollection;

        public List<int> distance { get; set; }
        public List<string> vehicletype { get; set; }
        public List<DateOnly> date { get; set; }
        public List<TimeOnly> startTime { get; set; }
        public List<TimeOnly> endTime { get; set; }
        public TripModel()
        {
            
        }
    }
}
