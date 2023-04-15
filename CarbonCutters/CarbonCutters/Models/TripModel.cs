using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using CarbonCuttersMockData;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
        /* Unsure removed in revert
        public int Id { get; set; }
        public string? userId { get; set; }
        public int distance { get; set; }
        public bool isDone { get; set; }
*/
        public IUserCollection userCollection;

        public int distance;
        public string vehicletype;
        public int Emission;
        public DateOnly date;
        public TimeOnly startTime;
        public TimeOnly endTime;
        public TripModel()
        {
            
        }
    }
}
