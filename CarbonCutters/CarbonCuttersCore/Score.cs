using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class Score
{
    public int points { get; private set; }

    public Score(int points)
    {
        this.points = points;
    }

    public string getPointsAsString()
    {
        return $"{points:n0}";
    }

    public Score()
    {
        points = 0;
    }

    public Score(DtoScore Dto)
    {
        points = Dto.points;
    }

    public void updatePoints(int points)
    {
        this.points = points;
    }
    public static int CalculateScore(int distance, string group, string method)
    {
        int zeroEmmision = 0;
        int perKmPoints = 0;
        int perKmPointsCar = 3;
        int carPoints = 0;
        int publicTransitPoints = 0;
        int airplane = 150;

        switch (group)
        {
            case "close distance":
                zeroEmmision = 160;
                carPoints = 10;
                perKmPoints = 5;
                publicTransitPoints = 150;
                break;
            case "medium distance":
                zeroEmmision = 220;
                carPoints = 20;
                perKmPoints = 1;
                publicTransitPoints = 180;
                break;
            case "long distance":
                zeroEmmision = 300;
                carPoints = 30;
                perKmPoints = 1;
                publicTransitPoints = 200;
                break;
            case "flight":
                airplane = 150;
                break;
            default:
                throw new ArgumentException("Invalid group");
        }

        int points = 0;

        switch (method)
        {
            case "zero emmision" when distance < 20.1:
                points = zeroEmmision + perKmPoints * Math.Max(distance - 10, 0);
                break;
            case "zero emmision" when distance >= 21:
                points = zeroEmmision;
                break;
            case "car":
                points = carPoints + perKmPointsCar * distance;
                break;
            case "public transit":
                points = publicTransitPoints;
                break;
            case "airplane":
                points = airplane;
                break;
            default:
                throw new ArgumentException("Invalid method");
        }

        return points;
    }
}
