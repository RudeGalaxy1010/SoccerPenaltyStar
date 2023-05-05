using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Score Score;

    [SerializeField] private GameObject _star;

    public void Construct(Score score)
    {
        Score = score;
    }

    public GameObject Star => _star;

    public void AddPoints(int value)
    {
        Score.AddPoints(value);
    }
}
