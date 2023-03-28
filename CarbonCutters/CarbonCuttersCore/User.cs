using CarbonCuttersCore.DTO;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class User
{
    public string name { get; private set; }
    public string picture { get; private set; }
    public string adress { get; private set; }
    public Score score { get; private set; }
    public ITripCollection tripCollection { get; private set; }
    public IVehicleCollection vehicleCollection { get; private set; }

    public User(string name, string picture, string adress, Score score, ITripCollection tripCollection, IVehicleCollection vehicleCollection)
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
        tripCollection = new TripCollection(Dto.tripCollection);
        vehicleCollection = new VehicleCollection(Dto.vehicleCollection);
    }

    public void edit(string name, string picture, string adress, Score score, ITripCollection tripCollection, IVehicleCollection vehicleCollection)
    {
        this.name = name;
        this.picture = picture;
        this.adress = adress;
        this.score = score;
        this.tripCollection = tripCollection;
        this.vehicleCollection = vehicleCollection;
    }
}
