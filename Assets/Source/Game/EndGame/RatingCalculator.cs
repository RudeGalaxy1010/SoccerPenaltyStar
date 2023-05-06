using UnityEngine;

public class RatingCalculator
{
    private const int MinWinRating = 30;
    private const int MaxWinRating = 35;

    private const int MinDefeatRating = -15;
    private const int MaxDefeatRating = -10;

    private const int DrawRating = 3;

    public int GetRandomWinRating()
    {
        return Random.Range(MinWinRating, MaxWinRating);
    }

    public int GetRandomDefeatRating()
    {
        return Random.Range(MinDefeatRating, MaxDefeatRating);
    }

    public int GetDrawRating()
    {
        return DrawRating;
    }
}
