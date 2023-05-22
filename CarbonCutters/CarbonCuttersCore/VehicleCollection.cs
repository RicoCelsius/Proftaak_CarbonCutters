using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;
using System.Reflection.PortableExecutable;

namespace CarbonCuttersCore;

public class VehicleCollection : IVehicleCollection
{
    private IVehicleCollection _vehicles { get; set; }
    public List<IVehicle> vehicles { get; private set; }


    public VehicleCollection(List<IVehicle> vehicles)
    {
        this.vehicles = vehicles;
    }

    public VehicleCollection()
    {
        vehicles = new();
    }

    public VehicleCollection(IVehicleCollection vehicleDal)
    {
        _vehicles = vehicleDal;
    }

    public Vehicle GetObject(string clas, string? Size, string? Fuel, string? Type1, string? Type2)
    {
        Vehicle? vehicle = null;

        if (clas == "Car")
        {
            fuel f = fuel.none;
            sizes s = sizes.none;

            if (Size == "small")
                s = sizes.small;
            else if (Size == "medium")
                s = sizes.medium;
            else if (Size == "large")
                s = sizes.large;

            if (Fuel == "electric")
                f = fuel.electric;
            else if (Fuel == "petrol")
                f = fuel.petrol;
            else if (Fuel == "diesel")
                f = fuel.diesel;
            else if (Fuel == "gas")
                f = fuel.gas;
            else if (Fuel == "hybrid")
                f = fuel.hybrid;

            vehicle = new Car(0 ,f, s);
        }
        else if (clas == "PublicTransport")
        {
            publicTransport t = publicTransport.tram;

            if (Type1 == "subway")
                t = publicTransport.subway;
            else if (Type1 == "bus")
                t = publicTransport.bus;
            else if (Type1 == "taxi")
                t = publicTransport.taxi;
            else if (Type1 == "train")
                t = publicTransport.train;

            vehicle = new PublicTransport(0, t);
        }
        else if (clas == "NoEmission")
        {
            noEmission t = noEmission.walking;

            if (Type2 == "biking")
                t = noEmission.biking;

            vehicle = new NoEmission(0, t);
        }

        if (vehicle == null)
            throw new Exception("Not a valid vehicle");
        return vehicle;
    }

    public void add(IVehicle vehicle)
    {
        vehicles.Add(vehicle);
        _vehicles.add(vehicle);
    }

    public void add(List<IVehicle> vehicles)
    {
        this.vehicles.AddRange(vehicles);
        _vehicles.add(vehicles);
    }

    public void remove(IVehicle vehicle)
    {
        vehicles.Remove(vehicle);
        _vehicles.remove(vehicle);
    }

    public void remove(List<IVehicle> vehiclelist)
    {
        while (vehiclelist.Count > 0)
            vehicles.Remove(vehiclelist[0]);
        _vehicles.remove(vehiclelist);
    }

    public IVehicle get(int id)
    {
        return _vehicles.get(id);
    }

    public int GetVehicleId(Vehicle vehicle)
    {
        return _vehicles.GetVehicleId(vehicle);
    }
}
