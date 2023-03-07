using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class VehicleCollection : IVehicleCollection
{
    public List<IVehicle> vehicles { get; private set; }


    public VehicleCollection(List<IVehicle> vehicles)
    {
        this.vehicles = vehicles;
    }

    public VehicleCollection()
    {
        vehicles = new();
    }

    public VehicleCollection(DtoVehicleCollection Dto)
    {
        vehicles = new();
        foreach (IVehicle vehicle in Dto.vehicles)
            vehicles.Add(vehicle);
    }

    public void add(IVehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void add(List<IVehicle> vehicles)
    {
        vehicles.AddRange(vehicles);
    }

    public void remove(IVehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }

    public void remove(List<IVehicle> vehicles)
    {
        foreach (IVehicle vehicle in vehicles)
            vehicles.Remove(vehicle);
    }
}
