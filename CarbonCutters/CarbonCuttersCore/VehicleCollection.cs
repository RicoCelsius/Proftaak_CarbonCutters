using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

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
        throw new NotImplementedException();
    }
}
