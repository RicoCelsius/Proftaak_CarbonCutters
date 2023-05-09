using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class Trip
{
    public int? id { get; private set; }
    public DateOnly dateTime { get; private set; }
    public List<TripSegment> segments { get; private set; }
    public int points { get; private set; }
    public bool isDone { get; private set; }

    public Trip(List<TripSegment> segments, int points, bool isDone, DateOnly dateTime)
    {
        this.segments = segments;
        this.points = points;
        this.isDone = isDone;
        this.dateTime = dateTime;
    }

    public Trip(List<TripSegment> segments, int points, bool isDone, DateOnly dateTime, int id) : this(segments, points, isDone, dateTime)
    {
        this.id = id;
    }

    public Trip(DtoTrip Dto)
    {
        segments = new();
        foreach (DtoTripSegment segment in Dto.segments)
            segments.Add(new(segment));
        points = Dto.emission;
        isDone = Dto.isDone;
    }

    public void Edit(List<TripSegment> segments, int emission, bool isDone)
    {
        this.segments = segments;
        this.points = emission;
        this.isDone = isDone;
    }

    public void AddSegment(TripSegment segment)
    {
        segments.Add(segment);
    }

    public void AddSegment(List<TripSegment> segments)
    {
        this.segments.AddRange(segments);
    }

    public void removeSegment(TripSegment segment)
    {
        segments.Remove(segment);
    }

    public void removeSegment(List<TripSegment> segments)
    {
        while (segments.Count > 0)
            this.segments.Remove(segments[0]);
    }
}