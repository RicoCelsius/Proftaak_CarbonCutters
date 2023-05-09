using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using Microsoft.Data.SqlClient;

namespace CarbonCuttersDAL;

public class TripCollectionDal : ITripCollection
{
    private string ConnectionString = @"Server=tcp:carboncutters.database.windows.net,1433;Initial Catalog=carboncutters;Persist Security Info=False;User ID=carboncutters;Password=G8!bjJGRhXwY!Yz7YDKn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private IVehicleCollection _vehicleCollectionDB { get; set; }
    public List<Trip> TripList { get; private set; }


    public TripCollectionDal(string userID, IVehicleCollection vehiclecollection)
    {
        _vehicleCollectionDB = vehiclecollection;
        TripList = GetTripsFromDB(userID);
    }

    public TripCollectionDal()
    {

    }

    private List<TripSegment> GetTripSegmentsFromDB(int tripID)
    {
        List<TripSegment> tripSegments = new List<TripSegment>();
        List<int> distances = new();
        List<int> vehicleIDs = new();
        List<TimeOnly> starttimes = new();
        List<TimeOnly> endTimes = new();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [distance],[vehicle_id],[startTime],[endTime] from [dbo].[trip_segment] where [trip_id] = '" + tripID + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                distances.Add(reader.GetInt32(0));
                vehicleIDs.Add(reader.GetInt32(1));
                starttimes.Add(TimeOnly.FromTimeSpan(reader.GetTimeSpan(2)));
                endTimes.Add(TimeOnly.FromTimeSpan(reader.GetTimeSpan(3)));
            }

        connection.Close();

        for (int i = 0; i < distances.Count; i++)
        {
            Vehicle vehicle = (Vehicle)_vehicleCollectionDB.get(vehicleIDs[i]);
            TripSegment segment = new(distances[i], vehicle, starttimes[i], endTimes[i]);
            tripSegments.Add(segment);
        }

        return tripSegments;
    }
    
    public List<Trip> GetTripsFromDB(string userID)
    {
        List<Trip> tripList = new List<Trip>();

        List<int> tripids = new();
        List<int> points = new();
        List<bool> dones = new();
        List<DateOnly> dates = new();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [trip_id],[points],[done],[Date] from [trip] where [authzero_user_id] = '" + userID + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                tripids.Add(reader.GetInt32(0));
                points.Add(reader.GetInt32(1));
                dones.Add(reader.GetBoolean(2));
                dates.Add(DateOnly.FromDateTime(reader.GetDateTime(3)));
            }

        for(int i = 0; i < tripids.Count; i++)
        {
            List<TripSegment> tripsegments = GetTripSegmentsFromDB(tripids[i]);
            Trip trip = new Trip(tripsegments , points[i], dones[i], dates[i], tripids[i]);
            tripList.Add(trip);
        }

        return tripList;
    }

    public void add(Trip trip)
    {
        throw new NotImplementedException();
    }

    public void add(List<Trip> trips)
    {
        throw new NotImplementedException();
    }

    public void remove(Trip trip)
    {
        throw new NotImplementedException();
    }

    public void remove(List<Trip> trips)
    {
        throw new NotImplementedException();
    }
}
