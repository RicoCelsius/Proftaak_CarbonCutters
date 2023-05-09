﻿using CarbonCuttersCore.DTO;

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
    public static int CalculateScore(int distance, string method)
    {
        int zeroEmmision = 0;
        int perKmPoints = 0;
        int perKmPointsCar = 3;
        int carPoints = 0;
        int publicTransitPoints = 0;
        int airplane = 150;

        switch (distance)
        {
            case int n when n < 20:
                zeroEmmision = 160;
                carPoints = 10;
                perKmPoints = 5;
                publicTransitPoints = 150;
                break;
        
            case int n when n < 50:
                zeroEmmision = 220;
                carPoints = 20;
                perKmPoints = 1;
                publicTransitPoints = 180;
                break;
            case int n when n >= 50:
                zeroEmmision = 300;
                carPoints = 30;
                perKmPoints = 1;
                publicTransitPoints = 200;
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
