using CarbonCuttersCore.Interface;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
        public int Id { get; set; }
        public string? userId { get; set; }
        public int distance { get; set; }
        public bool isDone { get; set; }

        public IUserCollection userCollection;
        public string vehicletype;
        public int Emission;
        public DateOnly date;
        public TimeOnly startTime;
        public TimeOnly endTime;

    }
}
