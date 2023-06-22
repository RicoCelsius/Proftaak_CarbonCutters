using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore.DTO;

public class DtoVehicleCollection
{
    public List<DtoVehicle> vehicles { get; private set; }

	public DtoVehicleCollection(List<DtoVehicle> vehicles)
	{
		this.vehicles = vehicles;
	}

	public DtoVehicleCollection(IVehicleCollection vehicleCollection)
	{
		vehicles = new();
		foreach (Car vehicle in vehicleCollection.vehicles.OfType<Car>())
			vehicles.Add(new DtoCar(vehicle));
		foreach (NoEmission vehicle in vehicleCollection.vehicles.OfType<NoEmission>())
			vehicles.Add(new DtoNoEmission(vehicle));
		foreach (PublicTransport vehicle in vehicleCollection.vehicles.OfType<PublicTransport>())
			vehicles.Add(new DtoPublicTransport(vehicle));
		foreach (Airplane vehicle in vehicleCollection.vehicles.OfType<Airplane>())
			vehicles.Add(new DtoAirplane(vehicle));
		foreach (LongDistanceTrain vehicle in vehicleCollection.vehicles.OfType<LongDistanceTrain>())
			vehicles.Add(new DtoLongDistanceTrain(vehicle));
		foreach (ToFromStation vehicle in vehicleCollection.vehicles.OfType<ToFromStation>())
			vehicles.Add(new DtoToFromStation(vehicle));
	}
}
