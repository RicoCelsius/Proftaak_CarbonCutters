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

    private List<TripSegment> GetTripSegmentsFromDB(int tripID)
    {
        List<TripSegment> tripSegments = new List<TripSegment>();
        List<int> distances = new();
        List<int> vehicleIDs = new();
        List<DateTime> datetimes = new();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [distance],[vehicle_id],[trip_date] from [dbo].[trip_segment] where [trip_id] = '" + tripID + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                distances.Add(reader.GetInt32(0));
                vehicleIDs.Add(reader.GetInt32(1));
                datetimes.Add(reader.GetDateTime(2));
            }

        connection.Close();

        for (int i = 0; i < distances.Count; i++)
        {
            Vehicle vehicle = (Vehicle)_vehicleCollectionDB.get(vehicleIDs[i]);
            TripSegment segment = new(distances[i], vehicle, datetimes[i]);
            tripSegments.Add(segment);
        }

        return tripSegments;
    }
    
    private List<Trip> GetTripsFromDB(string userID)
    {
        List<Trip> tripList = new List<Trip>();

        List<int> tripids = new();
        List<int> emissions = new();
        List<bool> dones = new();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [trip_id],[emission],[done] from [dbo].[trip] where [authzero_user_id] = '" + userID + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                tripids.Add(reader.GetInt32(0));
                emissions.Add(reader.GetInt32(1));
                dones.Add(reader.GetBoolean(2));
            }

        for(int i = 0; i < tripids.Count; i++)
        {
            List<TripSegment> tripsegments = GetTripSegmentsFromDB(tripids[i]);
            Trip trip = new Trip(tripsegments , emissions[i], dones[i]);
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
