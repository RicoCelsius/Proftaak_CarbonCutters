namespace CarbonCuttersCore.DTO;

public class DtoToFromStation : DtoVehicle
{
    public toFromStation type { get; private set; }

    public DtoToFromStation(int emission, toFromStation type) : base(emission)
    {
        this.type = type;
    }

    public DtoToFromStation(ToFromStation toFromStation) : base(toFromStation.emission)
    {
        this.type = toFromStation.type;
    }
}
