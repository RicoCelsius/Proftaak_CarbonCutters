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
}
