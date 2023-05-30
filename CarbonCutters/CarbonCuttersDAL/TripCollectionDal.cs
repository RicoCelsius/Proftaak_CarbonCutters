using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics;

namespace CarbonCuttersDAL;

public class TripCollectionDal : ITripCollection
{
    private string ConnectionString = @"Server=tcp:carboncutters.database.windows.net,1433;Initial Catalog=carboncutters;Persist Security Info=False;User ID=carboncutters;Password=G8!bjJGRhXwY!Yz7YDKn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private IVehicleCollection _vehicleCollectionDB { get; set; }
    private string UserID { get; set; }
    public List<Trip> TripList { get; private set; }
    


    public TripCollectionDal(string userID, IVehicleCollection vehiclecollection)
    {
        UserID = userID;
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
            Car car = new(3,fuel.diesel,sizes.large);
            TripSegment segment = new(distances[i], car, starttimes[i], endTimes[i]);
            tripSegments.Add(segment);
        }

        return tripSegments;
    }

    public List<Trip> GetAllTripsFromDB()
    {
        List<Trip> tripList = new List<Trip>();

        List<int> tripids = new();
        List<int> points = new();
        List<bool> dones = new();
        List<DateOnly> dates = new();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [trip_id],[points],[done],[Date] from [trip]",
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

        connection.Close();

        for (int i = 0; i < tripids.Count; i++)
        {
            List<TripSegment> tripsegments = GetTripSegmentsFromDB(tripids[i]);
            Trip trip = new Trip(tripsegments, points[i], dones[i], dates[i], tripids[i]);
            tripList.Add(trip);
        }

        return tripList;
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

        connection.Close();

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
        int tripID = 0;

        int done = 0;
        if (trip.isDone)
            done = 1;
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into trip (authzero_user_id, done, Date, points)" +
            "OUTPUT (INSERTED.trip_id) " +
            "values " +
            "('" + UserID + "'," + done + ",'" + trip.dateTime.ToString(@"yyyy-MM-dd") + "'," + trip.score.points + ")",
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
        {
            reader.Read();
            tripID = reader.GetInt32(0);
        }

        connection.Close();

        foreach (TripSegment segment in trip.segments)
            AddSegment(segment, tripID);
    }

    private void AddSegment(TripSegment segment, int id)
    {
        int vehicleID = _vehicleCollectionDB.GetVehicleId(segment.vehicle);

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into trip_segment (trip_id, vehicle_id, distance, emission, startTime, endTime)" +
            "values" +
            "(" + id + "," + vehicleID + "," + segment.distance + "," + segment.emission + ",'" + segment.startTime + "','" + segment.endTime + "')",
            connection);
        var reader = command.ExecuteReader();
        connection.Close();
    }

    public int CalculateTotalScoreOfUser(string id)
    {
        return 0;
    }
    public void add(List<Trip> trips)
    {
        throw new NotImplementedException();
    }

    public void remove(int id)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand("DELETE FROM trip WHERE trip_id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void remove(List<Trip> trips)
    {
        throw new NotImplementedException();
    }
}
