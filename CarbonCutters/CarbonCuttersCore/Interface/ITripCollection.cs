namespace CarbonCuttersCore.Interface;

public interface ITripCollection
{
    List<Trip> TripList { get; }

    void add(Trip trip);
    void add(List<Trip> trips);
    void remove(Trip trip);
    void remove(List<Trip> trips);
}
