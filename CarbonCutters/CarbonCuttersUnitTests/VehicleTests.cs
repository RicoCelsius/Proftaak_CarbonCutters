using CarbonCuttersCore;
using CarbonCuttersCore.DTO;

namespace CarbonCuttersUnitTests;

public class VehicleTests
{
    [Fact]
    public void CanMakeCar()
    {
        Vehicle vehicle = new Car(2, fuel.diesel, sizes.small);
        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanMakeNoEmission()
    {
        Vehicle vehicle = new NoEmission(0, noEmission.biking);
        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanMakePublicTransport()
    {
        Vehicle vehicle = new PublicTransport(2, publicTransport.bus);
        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanSwapToDto1()
    {
        Car vehicle = new Car(2, fuel.diesel, sizes.small);
        DtoVehicle Dto = new DtoCar(vehicle);

        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanSwapToDto2()
    {
        NoEmission vehicle = new NoEmission(0, noEmission.biking);
        DtoVehicle Dto = new DtoNoEmission(vehicle);

        Assert.NotNull(Dto);
    }

    [Fact]
    public void CanSwapToDto3()
    {
        PublicTransport vehicle = new PublicTransport(2, publicTransport.bus);
        DtoVehicle Dto = new DtoPublicTransport(vehicle);

        Assert.NotNull(Dto);
    }

    [Fact]
    public void CanSwapToNormal1()
    {
        DtoCar Dto = new DtoCar(2, fuel.diesel, sizes.small);
        Vehicle vehicle = new Car(Dto);

        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanSwapToNormal2()
    {
        DtoNoEmission Dto = new DtoNoEmission(0, noEmission.biking);
        Vehicle vehicle = new NoEmission(Dto);

        Assert.NotNull(vehicle);
    }

    [Fact]
    public void CanSwapToNormal3()
    {
        DtoPublicTransport Dto = new DtoPublicTransport(2, publicTransport.bus);
        Vehicle vehicle = new PublicTransport(Dto);

        Assert.NotNull(vehicle);
    }
}