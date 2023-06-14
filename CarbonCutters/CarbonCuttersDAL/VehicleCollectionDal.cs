using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace CarbonCuttersDAL;

public class VehicleCollectionDal : IVehicleCollection
{
    private string ConnectionString = @"Server=tcp:carboncutters.database.windows.net,1433;Initial Catalog=carboncutters;Persist Security Info=False;User ID=carboncutters;Password=G8!bjJGRhXwY!Yz7YDKn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    public List<IVehicle> vehicles { get; private set; }

    public VehicleCollectionDal()
    {

    }

    public IVehicle get(int id)
    {
        Vehicle? vehicle = null;
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [class],[type],[emission],[size],[fuel] FROM [vehicle] where [vehicle_id] = '" + id + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
        {
            reader.Read();
            string clas = reader.GetString(0);
            if (clas == "Car")
            {
                string S = reader.GetString(3);
                string F = reader.GetString(4);

                fuel f = fuel.none;
                sizes s = sizes.none;

                if (S == "small")
                    s = sizes.small;
                else if (S == "medium")
                    s = sizes.medium;
                else if (S == "large")
                    s = sizes.large;

                if (F == "electric")
                    f = fuel.electric;
                else if (F == "petrol")
                    f = fuel.petrol;
                else if (F == "diesel")
                    f = fuel.diesel;
                else if (F == "gas")
                    f = fuel.gas;
                else if (F == "hybrid")
                    f = fuel.hybrid;

                vehicle = new Car(reader.GetInt32(2), f, s);
            }
            else if (clas == "PublicTransport")
            {
                string T = reader.GetString(1);

                publicTransport t = publicTransport.tram;

                if (T == "subway")
                    t = publicTransport.subway;
                else if (T == "bus")
                    t = publicTransport.bus;
                else if (T == "taxi")
                    t = publicTransport.taxi;
                else if (T == "train")
                    t = publicTransport.train;

                vehicle = new PublicTransport(reader.GetInt32(2), t);
            }
            else if (clas == "NoEmission")
            {
                string T = reader.GetString(1);

                noEmission t = noEmission.walking;

                if (T == "biking")
                    t = noEmission.biking;

                vehicle = new NoEmission(reader.GetInt32(2), t);
            }
        }

        if (vehicle == null)
            throw new Exception("cant find vehicle");
        return vehicle;
    }

    public int GetVehicleId(Vehicle vehicle)
    {
        int id = -1;

        if (vehicle is Car)
            id = GetVehicleId((Car)vehicle);
        else if (vehicle is NoEmission)
            id = GetVehicleId((NoEmission)vehicle);
        else if (vehicle is PublicTransport)
            id = GetVehicleId((PublicTransport)vehicle);
        else if (vehicle is Airplane)
            id = GetVehicleId((Airplane)vehicle);
        else if (vehicle is LongDistanceTrain)
            id = GetVehicleId((LongDistanceTrain)vehicle);
        else if (vehicle is ToFromStation)
            id = GetVehicleId((ToFromStation)vehicle);

        return id;
    }

    private int GetVehicleId(Car vehicle)
    {
        int id = -1;
        string clas = "Car";
        int emission = vehicle.emission;
        string size = vehicle.size.ToString();
        string fuel = vehicle.fuel.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [emission] = " + emission + " " +
            "and [size] = '" + size + "' " +
            "and [fuel] = '" + fuel + "' ",
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        if (id == -1)
            id = add(null, clas, size, fuel, emission);

        return id;
    }

    private int GetVehicleId(NoEmission vehicle)
    {
        int id = -1;
        string clas = "NoEmission";
        int emission = vehicle.emission;
        string type = vehicle.type.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [type] = '" + type + "' " +
            "and [emission] = " + emission,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        if (id == -1)
            id = add(type, clas, null, null, emission);
        return id;
    }

    private int GetVehicleId(PublicTransport vehicle)
    {
        int id = -1;
        string clas = "PublicTransport";
        int emission = vehicle.emission;
        string type = vehicle.type.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [type] = '" + type + "' " +
            "and [emission] = " + emission,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        connection.Close();

        if (id == -1)
            id = add(type, clas, null, null, emission);
        return id;
    }

    private int GetVehicleId(Airplane vehicle)
    {
        int id = -1;
        string clas = "Airplane";
        int emission = vehicle.emission;
        string type = vehicle.type.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [type] = '" + type + "' " +
            "and [emission] = " + emission,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        connection.Close();

        if (id == -1)
            id = add(type, clas, null, null, emission);
        return id;
    }

    private int GetVehicleId(LongDistanceTrain vehicle)
    {
        int id = -1;
        string clas = "LongDistanceTrain";
        int emission = vehicle.emission;
        string type = vehicle.type.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [type] = '" + type + "' " +
            "and [emission] = " + emission,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        connection.Close();

        if (id == -1)
            id = add(type, clas, null, null, emission);
        return id;
    }
    private int GetVehicleId(ToFromStation vehicle)
    {
        int id = -1;
        string clas = "ToFromStation";
        int emission = vehicle.emission;
        string type = vehicle.type.ToString();

        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [vehicle_id] FROM [vehicle] where [class] = '" + clas + "' " +
            "and [type] = '" + type + "' " +
            "and [emission] = " + emission,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        connection.Close();

        if (id == -1)
            id = add(type, clas, null, null, emission);
        return id;
    }

    private int add(string? type, string clas, string? size, string? fuel, int emission)
    {
        int id = -1;
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into vehicle (type, class, size, fuel, emission)" +
            "output (INSERTED.vehicle_id)" +
            "values " +
            "('" + type + "','" + clas + "','" + size + "','" + fuel + "'," + emission + ")",
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

        connection.Close();

        return id;
    }

    public void add(IVehicle vehicle)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into vehicle (type, class, size, fuel, emission)" +
            "values " +
            "(",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void add(List<IVehicle> vehicles)
    {
        throw new NotImplementedException();
    }

    public void remove(IVehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public void remove(List<IVehicle> vehicles)
    {
        throw new NotImplementedException();
    }
}
