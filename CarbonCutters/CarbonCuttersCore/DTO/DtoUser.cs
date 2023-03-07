namespace CarbonCuttersCore.DTO;

public class DtoUser
{
    public string name { get; private set; }
    public string picture { get; private set; }
    public string adress { get; private set; }
    public DtoScore score { get; private set; }
    public DtoTripCollection tripCollection { get; private set; }
    public DtoVehicleCollection vehicleCollection { get; private set; }

    public DtoUser(string name, string picture, string adress, DtoScore score, DtoTripCollection tripCollection, DtoVehicleCollection vehicleCollection)
    {
        this.name = name;
        this.picture = picture;
        this.adress = adress;
        this.score = score;
        this.tripCollection = tripCollection;
        this.vehicleCollection = vehicleCollection;
    }

    public DtoUser(User user)
    {
        name = user.name;
        picture = user.picture;
        adress = user.adress;
        score = new(user.score);
        tripCollection = new(user.tripCollection);
        vehicleCollection = new(user.vehicleCollection);
    }
}
