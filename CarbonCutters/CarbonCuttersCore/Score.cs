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

    public void updatePoints(List<TripSegment> segments)
    {
        foreach (TripSegment segment in segments)
        {
            if (segment.vehicle is NoEmission)
                points += CalculateScore(segment.distance, "zero emmision");
            else if (segment.vehicle is Car)
                points += CalculateScore(segment.distance, "car");
            else if (segment.vehicle is PublicTransport)
                points += CalculateScore(segment.distance, "public transit");
            else if (segment.vehicle is Airplane)
                points += CalculateScore(segment.distance, "airplane");
            else if (segment.vehicle is ToFromStation)
                points += CalculateScore(segment.distance, "to from station");
            else if (segment.vehicle is LongDistanceTrain)
                points += CalculateScore(segment.distance, "long distance train");
        }
    }
    public static int CalculateScore(int distance, string method)
    {
        int zeroEmmision = 0;
        int perKmPoints = 0;
        int perKmPointsCar = 3;
        int carPoints = 0;
        int publicTransitPoints = 0;
        int airplane = 150;
        int longDriveReduction = 1;
        int toFromStation = 15;
        int LongDistanceTrain = 350;

        switch (distance)
        {
            case int n when n <= 20:
                zeroEmmision = 160;
                carPoints = 10;
                perKmPoints = 5;
                publicTransitPoints = 150;
                break;
        
            case int n when n < 50:
                zeroEmmision = 220;
                carPoints = 0;
                perKmPoints = 1;
                publicTransitPoints = 180;
                break;
            case int n when n >= 50:
                zeroEmmision = 300;
                carPoints = 30;
                perKmPoints = 1;
                publicTransitPoints = 200;
                longDriveReduction = 2;
                break;
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
                points = (carPoints + perKmPointsCar * distance) / longDriveReduction;
                break;
            case "public transit":
                points = publicTransitPoints;
                break;
            case "airplane":
                points = airplane;
                break;
            case "to from station":
                points = toFromStation;
                break;
            case "long distance train":
                points = LongDistanceTrain;
                break;
            default:
                throw new ArgumentException("Invalid method");
        }

        return points;
    }
}
