using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class TripSegment
{
    public int distance { get; private set; }
    public Vehicle vehicle { get; private set; }
    public DateTime dateTime { get; private set; }

    public TripSegment(int distance, Vehicle vehicle, DateTime dateTime)
    {
        this.distance = distance;
        this.vehicle = vehicle;
        this.dateTime = dateTime;
    }

    public TripSegment(DtoTripSegment Dto)
    {
        distance = Dto.distance;
        vehicle = Dto.vehicle;
        dateTime = Dto.dateTime;
    }

    public void edit(int distance, Vehicle vehicle, DateTime dateTime)
    {
        this.distance = distance;
        this.vehicle = vehicle;
        this.dateTime = dateTime;
    }
}
