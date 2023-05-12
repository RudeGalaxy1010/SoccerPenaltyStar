using System;

public class Dollars : IMoney
{
    public event Action<float> Changed;

    private const string NotEnoughMoneyToPurchaseExceptionMessage = "Not enough money to purchase";

    public float Value => DataHolder.PlayerData.Dollars;

    public void AddItemValue(ShopItem item)
    {
        DataHolder.PlayerData.Dollars += item.Value;
        Changed?.Invoke(DataHolder.PlayerData.Dollars);
    }

    public void PurchaseSkinPart(SkinPart skinPart)
    {
        if (DataHolder.PlayerData.Coins < skinPart.Cost)
        {
            throw new ArgumentException(NotEnoughMoneyToPurchaseExceptionMessage);
        }

        DataHolder.PlayerData.Coins -= skinPart.Cost;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }
}
