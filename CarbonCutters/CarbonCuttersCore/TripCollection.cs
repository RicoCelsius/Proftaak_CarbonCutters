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


    public List<ScoreData> CalculateAverageScoreOfAllUsers()
    {
        List<Trip> allTrips = GetAllTripsFromDB();
        List<ScoreData> scoreDataList = new();
        int amountOfTrips = 0;

        foreach (var trip in allTrips)
        {
            ScoreData existingData = scoreDataList.FirstOrDefault(x => x.Date == trip.dateTime.ToString());

            if (existingData != null)
            {
                amountOfTrips += 1;
                existingData.Score += trip.points / amountOfTrips;
            }
            else
            {
                ScoreData newScoreData = new ScoreData(trip.dateTime.ToString(),trip.points);
                scoreDataList.Add(newScoreData);
            }
        }

        return scoreDataList;
    }


    public List<Trip> GetAllTripsFromDB()
    {
        return _tripsDB.GetAllTripsFromDB();
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
