using CarbonCuttersCore;
using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersUnitTests;

public class VehicleCollectionTests
{
    [Fact]
    public void CanMakeVehicleCollection()
    {
        VehicleCollection vehicleCollection = new VehicleCollection();
        Assert.NotNull(vehicleCollection);
    }

    [Fact]
    public void CanAddSingleVehicleToCollection()
    {
        VehicleCollection vehicleCollection = new VehicleCollection();
        vehicleCollection.add(new Car(2, fuel.electric, sizes.large));
        Assert.Single(vehicleCollection.vehicles);
    }

    [Fact]
    public void CanAddMultipleVehiclesToCollection()
    {
        VehicleCollection vehicleCollection = new();
        List<IVehicle> vehicles = new List<IVehicle>();
        vehicles.Add(new Car(2, fuel.electric, sizes.small));
        vehicles.Add(new NoEmission(0, noEmission.biking));
        vehicleCollection.add(vehicles);
        Assert.Equal(2, vehicleCollection.vehicles.Count);
    }

    [Fact]
    public void CanRemoveVehicleFromCollection()
    {
        List<IVehicle> vehicles = new List<IVehicle>();
        Car car = new Car(2, fuel.electric, sizes.small);
        NoEmission nEmission = new NoEmission(0, noEmission.biking);

        vehicles.Add(car);
        vehicles.Add(nEmission);
        VehicleCollection vehicleCollection = new(vehicles);
        Assert.Equal(2, vehicleCollection.vehicles.Count);

        vehicleCollection.remove(car);
        Assert.Single(vehicleCollection.vehicles);
    }

    [Fact]
    public void CarRemoveMultipleVehiclesFromCollection()
    {
        List<IVehicle> vehicles = new List<IVehicle>();
        Car car = new Car(2, fuel.electric, sizes.small);
        NoEmission nEmission = new NoEmission(0, noEmission.biking);

        vehicles.Add(car);
        vehicles.Add(nEmission);
        VehicleCollection vehicleCollection = new(vehicles);
        Assert.Equal(2, vehicleCollection.vehicles.Count);

        vehicleCollection.remove(vehicles);
        Assert.Empty(vehicleCollection.vehicles);
    }

    [Fact]
    public void CanSwitchToDto()
    {
        VehicleCollection vehicleCollection = new VehicleCollection();
        DtoVehicleCollection Dto = new(vehicleCollection);
        Assert.NotNull(Dto);
    }

    [Fact]
    public void CanSwitchToClass()
    {
        List<DtoVehicle> vehicles = new List<DtoVehicle>();
        DtoCar car = new DtoCar(2, fuel.electric, sizes.small);
        DtoNoEmission nEmission = new DtoNoEmission(0, noEmission.biking);

        vehicles.Add(car);
        vehicles.Add(nEmission);

        DtoVehicleCollection Dto = new DtoVehicleCollection(vehicles);
        VehicleCollection vehicleCollection = new VehicleCollection(Dto);

        Assert.NotNull(vehicleCollection);
    }
}
