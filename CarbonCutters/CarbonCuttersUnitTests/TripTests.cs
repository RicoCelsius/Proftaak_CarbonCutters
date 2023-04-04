using CarbonCuttersCore;
using CarbonCuttersCore.DTO;

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
        Trip trip = new(segments, 200, false);
        trip.Edit(segments, 100, false);
        Assert.Equal(100, trip.emission);
    }

    [Fact]
    public void CanAddSegment()
    {
        segments.Add(new(200, car, now));
        Trip trip = new(segments, 200, false);
        trip.AddSegment(new TripSegment(50, car, now));
        Assert.Equal(2, trip.segments.Count);
    }

    [Fact]
    public void CanAddSegments()
    {
        segments.Add(new(200, car, now));
        Trip trip = new(segments, 200, false);
        trip.AddSegment(new List<TripSegment>() {new TripSegment(50, car, now), new TripSegment(20, car, now) });
        Assert.Equal(3, trip.segments.Count);
    }

    [Fact]
    public void CanRemoveSegment()
    {
        TripSegment segment = new(200, car, now);
        segments.Add(segment);
        Trip trip = new(segments, 200, false);
        trip.removeSegment(segment);
        Assert.Empty(trip.segments);
    }

    [Fact]
    public void CanRemoveSegments()
    {
        TripSegment segment = new(200, car, now);
        segments.Add(segment);
        segments.Add(segment);
        Trip trip = new(segments, 200, false);
        trip.removeSegment(segments);
        Assert.Empty(trip.segments);
    }

    [Fact]
    public void CanSwitchToDto()
    {
        TripSegment segment = new(200, car, now);
        segments.Add(segment);
        segments.Add(segment);
        Trip trip = new(segments, 200, false);
        DtoTrip Dto = new(trip);
        Assert.NotNull(Dto);
        Assert.Equal(segments.Count, Dto.segments.Count);
        Assert.Equal(200, Dto.emission);
        Assert.False(Dto.isDone);
    }

    [Fact]
    public void CanSwitchFromDto()
    {
        List<DtoTripSegment> segments = new();
        DtoTripSegment segment = new(200, car, now);
        segments.Add(segment);
        segments.Add(segment);
        DtoTrip Dto = new(segments, 200, false);
        Trip trip = new(Dto);
        Assert.NotNull(trip);
        Assert.Equal(segments.Count, trip.segments.Count);
        Assert.Equal(200, trip.emission);
        Assert.False(trip.isDone);
    }
}
