using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using CarbonCuttersMockData;

namespace CarbonCuttersView.Models
{
    public class TripModel
    {
        IUserCollection userCollection;
        public TripModel()
        {
            userCollection = new MockUsers(30, 100);
        }
    }
}
