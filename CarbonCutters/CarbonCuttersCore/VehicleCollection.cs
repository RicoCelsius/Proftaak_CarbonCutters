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
        foreach (DtoCar vehicle in Dto.vehicles.OfType<DtoCar>())
            vehicles.Add(new Car(vehicle));
        foreach (DtoNoEmission vehicle in Dto.vehicles.OfType<DtoNoEmission>())
            vehicles.Add(new NoEmission(vehicle));
        foreach (DtoPublicTransport vehicle in Dto.vehicles.OfType<DtoPublicTransport>())
            vehicles.Add(new PublicTransport(vehicle));
    }

    public void add(IVehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void add(List<IVehicle> vehicles)
    {
        this.vehicles.AddRange(vehicles);
    }

    public void remove(IVehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }

    public void remove(List<IVehicle> vehiclelist)
    {
        while (vehiclelist.Count > 0)
            vehicles.Remove(vehiclelist[0]);
    }
}
