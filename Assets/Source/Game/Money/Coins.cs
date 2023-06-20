using System;

public class Coins : IMoney
{
    public event Action<float> Changed;

    private const string NotEnoughMoneyToPurchaseExceptionMessage = "Not enough money to purchase";

    public const int WinMoney = 500;
    public const int DefeatMoney = 100;
    public const int DrawMoney = 250;
    public const int FreeMoney = 200;

    public float Value => DataHolder.PlayerData.Coins;
    Init initSDK;

    public void AddWinMoney()
    {
        DataHolder.PlayerData.Coins += WinMoney;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }

    public void SubDefeatMoney()
    {
        if (DataHolder.PlayerData.Coins < DefeatMoney)
        {
            DataHolder.PlayerData.Coins = 0;
        }

        DataHolder.PlayerData.Coins -= DefeatMoney;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }

    public void AddDrawMoney()
    {
        DataHolder.PlayerData.Coins += DrawMoney;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
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

    public void AddItemValue(ShopItem item)
    {
        DataHolder.PlayerData.Coins += item.Value;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }

    public void AddFreeMoney()
    {
        DataHolder.PlayerData.Coins += FreeMoney;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }
}
