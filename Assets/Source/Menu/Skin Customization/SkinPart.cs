using UnityEngine;

public class SkinPart : MonoBehaviour
{
    public int Id;
    public float Force;
    public float Accuracy;
    public float Luck;
    public CostType CostType;

    [HideInInspector] public int Cost;
}
