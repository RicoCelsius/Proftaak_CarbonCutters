
using CarbonCuttersCore;

namespace CarbonCuttersMockData;

internal class UserGenerator
{
    private static readonly Random r = new Random();
    private static string GenerateName(int len)
    {
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return Name;
    }

    public User next()
    {
        Score score = new(r.Next(10, 100000));
        TripCollection trips = new();
        trips.add(TripGenerator.Next(r.Next(3, 20)));
        return new User(GenerateName(r.Next(3,10)),GenerateName(r.Next(3,10)),"","",score,trips,new VehicleCollection());
    }
}
