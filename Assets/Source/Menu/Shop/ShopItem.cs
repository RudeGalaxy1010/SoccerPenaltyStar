using UnityEngine;

[CreateAssetMenu(fileName = "New shop item", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public int Value;
    public float Cost;

    private void OnValidate()
    {
        Cost = Mathf.RoundToInt(Cost * 100) / 100f;
    }
}
