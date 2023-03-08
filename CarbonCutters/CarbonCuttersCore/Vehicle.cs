using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public abstract class Vehicle : IVehicle
{
    public int emission { get; private set; }

    public Vehicle(int emission)
    {
        this.emission = emission;
    }

    public Vehicle(DtoVehicle dto)
    {
        this.emission = dto.emission;
    }

    public void updateEmission(int newEmission)
    {
        emission = newEmission;
    }
}