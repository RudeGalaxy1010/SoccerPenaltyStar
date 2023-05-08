using System;
using UnityEngine;

public class Dollars : IMoney
{
    public event Action<float> Changed;

    private const string NotEnoughMoneyToPurchaseExceptionMessage = "Not enough money to purchase item";

    public float Value => DataHolder.PlayerData.Dollars;

    public void PurchaseItem(ShopItem item)
    {
        if (DataHolder.PlayerData.Dollars < item.Cost)
        {
            throw new ArgumentException(NotEnoughMoneyToPurchaseExceptionMessage);
        }

        DataHolder.PlayerData.Dollars -= item.Cost;
        Changed?.Invoke(DataHolder.PlayerData.Dollars);
    }
}
