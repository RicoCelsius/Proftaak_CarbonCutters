namespace CarbonCuttersCore.DTO;

public class DtoTrip
{
    public List<DtoTripSegment> segments { get; private set; }
    public int emission { get; private set; }
    public bool isDone { get; private set; }

    public DtoTrip(List<DtoTripSegment> segments, int emission, bool isDone)
    {
        this.segments = segments;
        this.emission = emission;
        this.isDone = isDone;
    }

    public DtoTrip(Trip trip)
    {
        segments = new();
        foreach (TripSegment segment in trip.segments)
            segments.Add(new(segment));
        emission = trip.emission;
        isDone = trip.isDone;
    }
}
