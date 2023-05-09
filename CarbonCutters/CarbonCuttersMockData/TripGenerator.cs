using CarbonCuttersCore;

namespace CarbonCuttersMockData;

internal class TripGenerator
{
    private static readonly Random r = new();

    static public Trip Next()
    {
        bool isdone = false;
        if (r.Next(0,1) == 0)
            isdone = true;
        List<TripSegment> tripSegments = NextTripSegment(r.Next(1,3));

        return new Trip(tripSegments , r.Next(5, 1000), isdone, DateOnly.FromDateTime(DateTime.Now.AddDays(r.Next(-14,14))));
    }

    static public List<Trip> Next(int amount)
    {
        List<Trip> result = new List<Trip>();
        for (int i = 0; i < amount; i++)
            result.Add(Next());
        return result;
    }

    static private TripSegment NextTripSegment()
    {
        Car vehicle = new Car(r.Next(10, 500), fuel.gas, sizes.small);
        return new TripSegment(r.Next(10, 400), vehicle , TimeOnly.FromDateTime(DateTime.Now.AddHours(r.Next(-6,0))), TimeOnly.FromDateTime(DateTime.Now.AddHours(r.Next(0, 6))));
    }

    static private List<TripSegment> NextTripSegment(int amount)
    {
        List<TripSegment> result = new();
        for (int i = 0; i < amount; i++)
            result.Add(NextTripSegment());
        return result;
    }
}
