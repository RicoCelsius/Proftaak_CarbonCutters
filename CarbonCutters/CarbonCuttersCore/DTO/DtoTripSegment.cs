namespace CarbonCuttersCore.DTO;

public class DtoTripSegment
{
    public int distance { get; private set; }
    public Vehicle vehicle { get; private set; }
    public DateTime dateTime { get; private set; }

    public DtoTripSegment(int distance, Vehicle vehicle, DateTime dateTime)
    {
        this.distance = distance;
        this.vehicle = vehicle;
        this.dateTime = dateTime;
    }

    public DtoTripSegment(TripSegment tripSegment)
    {
        distance = tripSegment.distance;
        vehicle = tripSegment.vehicle;
    }
}
