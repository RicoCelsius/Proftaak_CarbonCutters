namespace CarbonCuttersCore.DTO;

public class DtoUser
{
    public string id { get; private set; }
    public string name { get; private set; }
    public string picture { get; private set; }
    public string adress { get; private set; }
    public DtoScore score { get; private set; }
    public DtoTripCollection tripCollection { get; private set; }
    public DtoVehicleCollection vehicleCollection { get; private set; }

    public DtoUser(string id, string name, string picture, string adress, DtoScore score, DtoTripCollection tripCollection, DtoVehicleCollection vehicleCollection)
    {
        this.id = id;
        this.name = name;
        this.picture = picture;
        this.adress = adress;
        this.score = score;
        this.tripCollection = tripCollection;
        this.vehicleCollection = vehicleCollection;
    }

    public DtoUser(User user)
    {
        id = user.id;
        name = user.name;
        picture = user.picture;
        adress = user.adress;
        score = new(user.score);
        tripCollection = new DtoTripCollection(user.tripCollection);
        vehicleCollection = new DtoVehicleCollection(user.vehicleCollection);
    }
}
