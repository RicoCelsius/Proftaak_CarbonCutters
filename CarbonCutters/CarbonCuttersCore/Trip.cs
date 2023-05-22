namespace CarbonCuttersCore;

public class Trip
{
    public int? id { get; set; }
    public DateOnly dateTime { get; private set; }
    public List<TripSegment> segments { get; private set; }
    public bool isDone { get; private set; }
    public Score score { get; private set; }

    public Trip(List<TripSegment> segments, bool isDone, DateOnly dateTime)
    {
        score = new Score();
        score.updatePoints(segments);
        this.segments = segments;
        this.isDone = isDone;
        this.dateTime = dateTime;
    }

    public Trip(List<TripSegment> segments,int points, bool isDone, DateOnly dateTime) : this(segments,isDone,dateTime)
    {
        score = new Score();
        score.updatePoints(points);
    }

    public Trip(List<TripSegment> segments, int points, bool isDone, DateOnly dateTime, int id) : this(segments,points,isDone,dateTime)
    {
        this.id = id;
    }

    public void Edit(List<TripSegment> segments, bool isDone)
    {
        this.segments = segments;
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