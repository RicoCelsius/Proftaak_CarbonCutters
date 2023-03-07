using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class User
{
    public string name { get; private set; }
    public string picture { get; private set; }
    public string adress { get; private set; }
    public Score score { get; private set; }
    public TripCollection tripCollection { get; private set; }
    public VehicleCollection vehicleCollection { get; private set; }

    public User(string name, string picture, string adress, Score score, TripCollection tripCollection, VehicleCollection vehicleCollection)
    {
        this.name = name;
        this.picture = picture;
        this.adress = adress;
        this.score = score;
        this.tripCollection = tripCollection;
        this.vehicleCollection = vehicleCollection;
    }

    public User(DtoUser Dto)
    {
        name = Dto.name;
        picture = Dto.picture;
        adress = Dto.adress;
        score = new(Dto.score);
        tripCollection = new(Dto.tripCollection);
        vehicleCollection = new(Dto.vehicleCollection);
    }

    public void edit(string name, string picture, string adress, Score score, TripCollection tripCollection, VehicleCollection vehicleCollection)
    {
        this.name = name;
        this.picture = picture;
        this.adress = adress;
        this.score = score;
        this.tripCollection = tripCollection;
        this.vehicleCollection = vehicleCollection;
    }
}
