using System;

public class Coins : IMoney
{
    public event Action<float> Changed;

    private const string NotEnoughMoneyToPurchaseSkinExceptionMessage = "Not enough money to purchase skin part";

    private const int WinMoney = 500;
    private const int DefeatMoney = 100;
    private const int DrawMoney = 250;

    public float Value => DataHolder.PlayerData.Coins;

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

    public void AddItemMoney(ShopItem item)
    {
        DataHolder.PlayerData.Coins += item.Value;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }

    public void PurchaseSkinPart(SkinPart skinPart)
    {
        if (DataHolder.PlayerData.Coins < skinPart.Cost)
        {
            throw new ArgumentException(NotEnoughMoneyToPurchaseSkinExceptionMessage);
        }

        DataHolder.PlayerData.Coins -= skinPart.Cost;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }

    public void AddFromItem(ShopItem item)
    {
        DataHolder.PlayerData.Coins += item.Value;
        Changed?.Invoke(DataHolder.PlayerData.Coins);
    }
}
