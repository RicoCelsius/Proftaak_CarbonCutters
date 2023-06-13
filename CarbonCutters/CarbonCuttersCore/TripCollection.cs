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
        Dictionary<string, (int totalPoints, int tripCount)> scoreDataDict = new Dictionary<string, (int, int)>();

        foreach (var trip in allTrips)
        {
            string tripDate = trip.dateTime.ToString("yyyy-MM-dd");

            if (scoreDataDict.ContainsKey(tripDate))
            {
                var (totalPoints, tripCount) = scoreDataDict[tripDate];
                totalPoints += trip.score.points;
                tripCount += 1;
                scoreDataDict[tripDate] = (totalPoints, tripCount);
            }
            else
            {
                scoreDataDict[tripDate] = (trip.score.points, 1);
            }
        }

        List<ScoreData> scoreDataList = new List<ScoreData>();

        foreach (var kvp in scoreDataDict)
        {
            string date = kvp.Key;
            var (totalPoints, tripCount) = kvp.Value;
            int averageScore = totalPoints / tripCount;

            ScoreData scoreData = new ScoreData(date, averageScore);
            scoreDataList.Add(scoreData);
        }

        return scoreDataList;
    }



    public List<ScoreData> CalculateAverageScoreOfUser(string id)
    {
        List<Trip> allTrips = _tripsDB.GetTripsFromDB(id);
        List<ScoreData> scoreDataList = new List<ScoreData>();
        Dictionary<string, (int totalPoints, int tripCount)> scoreDataDict = new Dictionary<string, (int, int)>();

        foreach (var trip in allTrips)
        {
            string tripDate = trip.dateTime.ToString("yyyy-MM-dd");

            if (scoreDataDict.ContainsKey(tripDate))
            {
                var (totalPoints, tripCount) = scoreDataDict[tripDate];
                totalPoints += trip.score.points;
                tripCount += 1;
                scoreDataDict[tripDate] = (totalPoints, tripCount);
            }
            else
            {
                scoreDataDict[tripDate] = (trip.score.points, 1);
            }
        }

        foreach (var kvp in scoreDataDict)
        {
            string date = kvp.Key;
            var (totalPoints, tripCount) = kvp.Value;
            int averageScore = totalPoints / tripCount;

            ScoreData scoreData = new ScoreData(date, averageScore);
            scoreDataList.Add(scoreData);
        }

        return scoreDataList;
    }

    public int CalculateTotalScoreOfUser(string id)
    {
        List<Trip> allTrips = _tripsDB.GetTripsFromDB(id);
        int totalScore = 0;
        foreach (var trip in allTrips)
        {
            totalScore += trip.score.points;
        }
        return totalScore;
    }


    public List<Trip> GetAllTripsFromDB()
    {
        return _tripsDB.GetAllTripsFromDB();
    }

    public Trip getTrip(int id)
    {
        List<Trip> trips = GetAllTripsFromDB();
        foreach (Trip trip in trips)
        {
            if (trip.id == id)
                return trip;
        }
        return null;
    }

    public List<Trip> GetTripsFromDB(string id)
    {
        return _tripsDB.GetTripsFromDB(id);
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

    public void remove(int id)
    {
        _tripsDB.remove(id);
    }

    public void remove(List<Trip> trips)
    {
        while (trips.Count > 0)
            TripList.Remove(trips[0]);
    }
}
