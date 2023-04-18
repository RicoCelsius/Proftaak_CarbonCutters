using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using Microsoft.Data.SqlClient;
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
            "select [class],[type],[emission],[size],[fuel] from [dbo].[vehicle] where [vehicle_id] = '" + id + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
        {
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

    public void add(IVehicle vehicle)
    {
        throw new NotImplementedException();
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
