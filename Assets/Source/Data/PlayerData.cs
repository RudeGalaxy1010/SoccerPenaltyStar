using System;

[Serializable]
public class PlayerData
{
    public SkinData PlayerSkinData;
    public SkinData BotSkinData;
    public UnlockedParts UnlockedParts;
    public int PlayerRating;
    public int Money;

    public PlayerData()
    {
        PlayerSkinData = new SkinData();
        BotSkinData = new SkinData();
        UnlockedParts = new UnlockedParts();
        PlayerRating = 1000;
        Money = 0;
    }
}
