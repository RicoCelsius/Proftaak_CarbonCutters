namespace CarbonCuttersCore.DTO;

public class DtoLongDistanceTrain : DtoVehicle
{
    public longDistanceTrain type { get; private set; }

    public DtoLongDistanceTrain(int emission, longDistanceTrain type) : base(emission)
    {
        this.type = type;
    }

    public DtoLongDistanceTrain(LongDistanceTrain longDistanceTrain) : base(longDistanceTrain.emission)
    {
        this.type = longDistanceTrain.type;
    }
}
