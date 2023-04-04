using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class Car : Vehicle
{
    public int passengers { get; private set; }
    public sizes size { get; private set; }
    public fuel fuel { get; private set; }

    public Car(int emission, fuel fuel, sizes size) : base(emission)
    {
        this.fuel = fuel;
        this.size = size;
    }

    public Car(DtoCar Dto) : base(Dto.emission)
    {
        this.fuel = Dto.fuel;
        this.size = Dto.size;
    }
}
