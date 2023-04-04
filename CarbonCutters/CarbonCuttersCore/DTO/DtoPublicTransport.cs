namespace CarbonCuttersCore.DTO;

public class DtoPublicTransport : DtoVehicle
{
    public publicTransport type { get; private set; }

    public DtoPublicTransport(int emission, publicTransport type) : base(emission)
    {
        this.type = type;
    }

    public DtoPublicTransport(PublicTransport publicTransport) : base(publicTransport.emission)
    {
        this.type = publicTransport.type;
    }
}
