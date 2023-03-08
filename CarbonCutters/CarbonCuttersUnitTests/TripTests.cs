using CarbonCuttersCore;

namespace CarbonCuttersUnitTests;

public class TripTests
{
    List<TripSegment> segments = new();
    Car car = new Car(2, fuel.diesel, sizes.small);
    DateTime now = DateTime.Now;

    [Fact]
    public void CanMakeTrip()
    {
        segments.Add(new(200, car, now));
        segments.Add(new(50, car, now));
        Trip trip = new(segments, 200, false);
        Assert.NotNull(trip);
        Assert.Equal(segments, trip.segments);
        Assert.Equal(200, trip.emission);
        Assert.False(trip.isDone);
    }

    [Fact]
    public void CanEditTrip()
    {
        segments.Add(new(200, car, now));
        segments.Add(new(50, car, now));

    }
}
