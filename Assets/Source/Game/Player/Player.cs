using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Score Score;

    [SerializeField] private GameObject _star;
    [SerializeField] private SkinApplier _skinApplier;

    public void Construct(Score score, Skin skinPrefab, SkinData skinData)
    {
        Score = score;
        _skinApplier.Construct(skinPrefab, skinData);
    }

    public GameObject Star => _star;

    public void AddPoints(int value)
    {
        Score.AddPoints(value);
    }
}
