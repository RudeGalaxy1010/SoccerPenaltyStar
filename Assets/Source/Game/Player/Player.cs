using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Score Score;

    [SerializeField] private GameObject _star;
    [SerializeField] private SkinApplier _skinApplier;

    public void Construct(Score score, SkinCustomization skinPrefab, SkinCustomizationData skinCustomizationData)
    {
        Score = score;
        _skinApplier.Construct(skinPrefab, skinCustomizationData);
    }

    public GameObject Star => _star;

    public void AddPoints(int value)
    {
        Score.AddPoints(value);
    }
}
