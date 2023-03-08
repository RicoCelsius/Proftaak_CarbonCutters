using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class PublicTransport : Vehicle
{
    public publicTransport type { get; private set; }

    public PublicTransport(int emission, publicTransport type) : base(emission)
    {
        this.type = type;
    }

    public PublicTransport(DtoPublicTransport Dto) : base(Dto.emission)
    {
        this.type = Dto.type;
    }
}
