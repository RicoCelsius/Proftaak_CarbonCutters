using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class Trip
{
    public List<TripSegment> segments { get; private set; }
    public int emission { get; private set; }
    public  bool isDone { get; private set; }

    public Trip(List<TripSegment> segments, int emission, bool isDone)
    {
        this.segments = segments;
        this.emission = emission;
        this.isDone = isDone;
    }

    public Trip(DtoTrip Dto)
    {
        segments = new();
        foreach (DtoTripSegment segment in Dto.segments)
            segments.Add(new(segment));
        emission = Dto.emission;
        isDone = Dto.isDone;
    }

    public void Edit(List<TripSegment> segments, int emission, bool isDone)
    {
        this.segments = segments;
        this.emission = emission;
        this.isDone = isDone;
    }
}