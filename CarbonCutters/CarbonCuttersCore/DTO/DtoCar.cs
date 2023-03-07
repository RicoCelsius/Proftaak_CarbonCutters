namespace CarbonCuttersCore.DTO;

public class DtoCar : DtoVehicle
{
    public int passengers { get; private set; }
    public sizes size { get; private set; }
    public fuel fuel { get; private set; }

    public DtoCar(int emission, fuel fuel, sizes size) : base(emission)
    {
        this.fuel = fuel;
        this.size = size;
    }

    public DtoCar(Car car) : base(car.emission)
    {
        this.fuel = car.fuel;
        this.size = car.size;
    }
}
