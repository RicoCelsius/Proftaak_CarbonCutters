using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class TripCollection : ITripCollection
{
    private ITripCollection _tripsDB;
    public List<Trip> TripList { get; private set; }

    public TripCollection()
    {
        TripList = new List<Trip>();
    }

    public TripCollection(ITripCollection tripsDB)
    {
        _tripsDB = tripsDB;
        TripList = _tripsDB.TripList;
    }

    public TripCollection(List<Trip> tripList)
    {
        TripList = tripList;
    }

    public void add(Trip trip)
    {
        TripList.Add(trip);
        _tripsDB.add(trip);
    }

    public void add(List<Trip> trips)
    {
        TripList.AddRange(trips);
    }

    public void remove(Trip trip)
    {
        TripList.Remove(trip);
    }

    public void remove(List<Trip> trips)
    {
        while (trips.Count > 0)
            TripList.Remove(trips[0]);
    }
}
