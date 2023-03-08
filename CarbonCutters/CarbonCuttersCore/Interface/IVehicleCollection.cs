namespace CarbonCuttersCore.Interface;

public interface IVehicleCollection
{
    List<IVehicle> vehicles { get; }

    void add(IVehicle vehicle);
    void add(List<IVehicle> vehicles);
    void remove(IVehicle vehicle);
    void remove(List<IVehicle> vehicles);
}
