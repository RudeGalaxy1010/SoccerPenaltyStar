using System;

public class Dollars : IMoney
{
    public event Action<float> Changed;

    private const string NotEnoughMoneyToPurchaseExceptionMessage = "Not enough money to purchase item";

    public float Value => DataHolder.PlayerData.Dollars;

    public void AddItemValue(ShopItem item)
    {
        DataHolder.PlayerData.Dollars += item.Value;
        Changed?.Invoke(DataHolder.PlayerData.Dollars);
    }
}
