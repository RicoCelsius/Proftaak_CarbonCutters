namespace CarbonCuttersCore.Interface;

public interface IVehicle
{
    int emission { get; }

    void updateEmission(int newEmission);
}
