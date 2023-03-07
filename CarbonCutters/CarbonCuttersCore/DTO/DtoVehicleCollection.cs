using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore.DTO;

public class DtoVehicleCollection
{
    public List<IVehicle> vehicles { get; private set; }

	public DtoVehicleCollection(List<IVehicle> vehicles)
	{
		this.vehicles = vehicles;
	}

	public DtoVehicleCollection(VehicleCollection vehicleCollection)
	{
		vehicles = vehicleCollection.vehicles;
	}
}
