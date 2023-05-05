using System;

public class Score
{
    private const string NegativeScoreExceptionMessage = "Can't add negative value to score";

    public event Action<int> ScoreChanged;

    private int _points;

    public int Points => _points;

    public void AddPoints(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(NegativeScoreExceptionMessage);
        }

        _points += value;
        ScoreChanged?.Invoke(_points);
    }
}
