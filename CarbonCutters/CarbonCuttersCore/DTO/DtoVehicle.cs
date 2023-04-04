namespace CarbonCuttersCore.DTO;

public abstract class DtoVehicle
{
    public int emission { get; private set; }

	public DtoVehicle(int emission)
	{
		this.emission = emission;
	}

	public DtoVehicle(Vehicle vehicle)
	{
		this.emission = vehicle.emission;
	}
}
