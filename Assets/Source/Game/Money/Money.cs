using System;

public class Money
{
    public event Action<int> MoneyChanged;

    private const int WinMoney = 500;
    private const int DefeatMoney = 100;
    private const int DrawMoney = 250;

    public int Value => DataHolder.PlayerData.Money;

    public void AddWinMoney()
    {
        DataHolder.PlayerData.Money += WinMoney;
        MoneyChanged?.Invoke(DataHolder.PlayerData.Money);
    }

    public void SubDefeatMoney()
    {
        if (DataHolder.PlayerData.Money < DefeatMoney)
        {
            DataHolder.PlayerData.Money = 0;
        }

        DataHolder.PlayerData.Money -= DefeatMoney;
        MoneyChanged?.Invoke(DataHolder.PlayerData.Money);
    }

    public void AddDrawMoney()
    {
        DataHolder.PlayerData.Money += DrawMoney;
        MoneyChanged?.Invoke(DataHolder.PlayerData.Money);
    }
}
