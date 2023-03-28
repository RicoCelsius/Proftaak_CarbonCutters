namespace CarbonCuttersCore.DTO;

public class DtoScore
{
    public int points { get; private set; }

	public DtoScore(int points)
	{
		this.points = points;
	}

	public DtoScore(Score score)
	{
		points = score.points;
	}
}
