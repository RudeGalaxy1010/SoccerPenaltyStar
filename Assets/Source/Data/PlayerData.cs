using System;

[Serializable]
public class PlayerData
{
    public SkinData PlayerSkinData;
    public SkinData BotSkinData;
    public UnlockedParts UnlockedParts;
    public int PlayerRating;
    public int Coins;
    public float Dollars;

    public PlayerData()
    {
        PlayerSkinData = new SkinData();
        BotSkinData = new SkinData();
        UnlockedParts = new UnlockedParts();
        PlayerRating = 1000;
        Coins = 0;
        Dollars = 0;
    }
}
