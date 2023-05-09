using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using CarbonCuttersMockData;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
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
