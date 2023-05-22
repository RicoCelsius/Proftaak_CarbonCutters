namespace CarbonCuttersCore.Interface;

public interface ITripCollection
{
    List<Trip> TripList { get; }

    void add(Trip trip);
    void add(List<Trip> trips);
    List<Trip> GetAllTripsFromDB();
    List<Trip> GetTripsFromDB(string id);
    int CalculateTotalScoreOfUser(string ud);
    void remove(Trip trip);
    void remove(List<Trip> trips);
}
