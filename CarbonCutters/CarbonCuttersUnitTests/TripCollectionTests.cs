using CarbonCuttersCore;
using CarbonCuttersCore.DTO;

namespace CarbonCuttersUnitTests;

public class TripCollectionTests
{
    static Car car = new Car(2, fuel.diesel, sizes.small);
    static DateTime now = DateTime.Now;
    static List<TripSegment> segments = new() { new(200, car, now), new(50, car, now) };
    static Trip trip = new(segments, 200, false);
    List<Trip> trips = new (new List<Trip>() { trip, trip, trip });

    [Fact]
    public void CanMakeEmptyTripCollection()
    {
        TripCollection tripCollection = new TripCollection();
        Assert.NotNull(tripCollection);
        Assert.Empty(tripCollection.TripList);
    }

    [Fact]
    public void CanMakeFullTripCollection()
    {
        TripCollection tripCollection = new TripCollection(trips);
        Assert.NotNull(tripCollection);
        Assert.NotEmpty(tripCollection.TripList);
    }

    [Fact]
    public void CanAddTrip()
    {
        TripCollection tripCollection = new TripCollection();
        tripCollection.add(trip);
        Assert.NotEmpty(tripCollection.TripList);
    }

    [Fact]
    public void CanAddTrips()
    {
        TripCollection tripCollection = new TripCollection();
        tripCollection.add(trips);
        Assert.Equal(3, tripCollection.TripList.Count);
    }

    [Fact]
    public void CanRemoveTrip()
    {
        TripCollection tripCollection = new TripCollection(trips);
        tripCollection.remove(trip);
        Assert.Equal(2, tripCollection.TripList.Count);
    }

    [Fact]
    public void CanRemoveTrips()
    {
        TripCollection tripCollection = new TripCollection(trips);
        tripCollection.remove(trips);
        Assert.Empty(tripCollection.TripList);
    }

    [Fact]
    public void CanSwapToDto()
    {
        TripCollection tripCollection = new TripCollection(trips);
        DtoTripCollection Dto = new(tripCollection);
        Assert.NotNull(Dto);
        Assert.Equal(trips.Count, Dto.TripList.Count);
    }

    [Fact]
    public void CanSwapFromDto()
    {
        List<DtoTrip> DtoTrips = new();
        DtoTripCollection Dto = new DtoTripCollection(DtoTrips);
        TripCollection trips = new(Dto);
        Assert.NotNull(trips);
        Assert.Equal(DtoTrips.Count, trips.TripList.Count);
    }
}
