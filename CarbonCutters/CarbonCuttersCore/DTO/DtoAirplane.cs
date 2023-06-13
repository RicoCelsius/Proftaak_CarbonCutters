namespace CarbonCuttersCore.DTO;

public class DtoAirplane : DtoVehicle
{
    public airplane type { get; private set; }

    public DtoAirplane(int emission, airplane type) : base(emission)
    {
        this.type = type;
    }

    public DtoAirplane(Airplane airplane) : base(airplane.emission)
    {
        this.type = airplane.type;
    }
}
