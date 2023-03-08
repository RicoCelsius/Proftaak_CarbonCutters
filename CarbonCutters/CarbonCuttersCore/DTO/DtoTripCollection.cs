
namespace CarbonCuttersCore.DTO;

public class DtoTripCollection
{
    public List<DtoTrip> TripList { get; private set; }

	public DtoTripCollection(List<DtoTrip> tripList)
	{
		TripList = tripList;
	}

	public DtoTripCollection(TripCollection tripCollection)
	{
		TripList = new();
		foreach (Trip trip in tripCollection.TripList)
			TripList.Add(new(trip));
	}
}
