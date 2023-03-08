using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class TripCollection : ITripCollection
{
    public List<Trip> TripList { get; private set; }

    public TripCollection()
    {
        TripList = new List<Trip>();
    }

    public TripCollection(DtoTripCollection Dto)
    {
        TripList = new();
        foreach (DtoTrip trip in Dto.TripList)
            TripList.Add(new(trip));
    }

    public TripCollection(List<Trip> tripList)
    {
        TripList = tripList;
    }

    public void add(Trip trip)
    {
        TripList.Add(trip);
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
        foreach (Trip trip in trips)
            TripList.Remove(trip);
    }
}
