using CarbonCuttersCore;

namespace CarbonCuttersView.Models
{
    public class TripSegmentModel
    {
        public int distance { get; set; }
        public DateTime date { get; set; }
        public Vehicle vehicle { get; set; }

        public TripSegmentModel()
        {

        }
    }
}
