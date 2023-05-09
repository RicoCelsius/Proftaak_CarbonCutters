using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class TripSegment
{
    public int distance { get; private set; }
    public Vehicle vehicle { get; private set; }
    public TimeOnly startTime { get; private set; }
    public TimeOnly endTime { get; private set; }

    public TripSegment(int distance, Vehicle vehicle, TimeOnly start, TimeOnly end)
    {
        this.distance = distance;
        this.vehicle = vehicle;
        startTime = start;
        endTime = end;
    }

    public TripSegment(DtoTripSegment Dto)
    {
        distance = Dto.distance;
        vehicle = Dto.vehicle;
    }

    public void edit(int distance, Vehicle vehicle, TimeOnly start, TimeOnly end)
    {
        this.distance = distance;
        this.vehicle = vehicle;
        startTime = start;
        endTime = end;
    }
}
