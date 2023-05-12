using System;

public interface IMoney
{
    public event Action<float> Changed;
    public float Value { get; }

    public void AddItemValue(ShopItem item);
}
