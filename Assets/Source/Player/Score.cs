using System;

public class Score
{
    private const string NegativeScoreExceptionMessage = "Can't add negative value to score";

    public event Action<int> ScoreChanged;

    private int _score;

    public void AddPoints(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(NegativeScoreExceptionMessage);
        }

        _score += value;
        ScoreChanged?.Invoke(_score);
    }
}
