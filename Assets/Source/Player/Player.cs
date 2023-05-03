using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Score Score;

    public void Construct(Score score)
    {
        Score = score;
    }

    public void AddPoints(int value)
    {
        Score.AddPoints(value);
    }
}
