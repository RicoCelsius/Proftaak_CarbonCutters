using CarbonCuttersCore;
using CarbonCuttersCore.DTO;

namespace CarbonCuttersUnitTests;

public class TripSegmentTests
{
    Car car = new Car(2, fuel.gas, sizes.small);
    DateTime now = DateTime.Now;

    [Fact]
    public void CanMakeTripSegment()
    {
        TripSegment segment = new TripSegment(400, car, now);
        Assert.NotNull(segment);
        Assert.Equal(car, segment.vehicle);
        Assert.Equal(now, segment.dateTime);
    }

    [Fact]
    public void CanEditTripSegment()
    {
        
        TripSegment segment = new TripSegment(400, car, now);
        segment.edit(200, car, now);
        Assert.Equal(200, segment.distance);
    }

    [Fact]
    public void CanSwapToDto()
    {
        TripSegment segment = new TripSegment(400, car, now);
        DtoTripSegment Dto = new(segment);
        Assert.NotNull(Dto);
        Assert.Equal(400, Dto.distance);
        Assert.Equal(car, Dto.vehicle);
        Assert.Equal(now, Dto.dateTime);
    }

    [Fact]
    public void CanSwapToNormal()
    {
        DtoTripSegment Dto = new DtoTripSegment(400, car, now);
        TripSegment segment = new(Dto);
        Assert.NotNull(segment);
        Assert.Equal(400, segment.distance);
        Assert.Equal(car, segment.vehicle);
        Assert.Equal(now, segment.dateTime);
    }
}
