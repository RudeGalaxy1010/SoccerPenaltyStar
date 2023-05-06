using System;

[Serializable]
public class PlayerData
{
    public SkinCustomizationData PlayerSkinCustomizationData;
    public SkinCustomizationData BotSkinCustomizationData;
    public int PlayerRating;
    public int Money;

    public PlayerData()
    {
        PlayerSkinCustomizationData = new SkinCustomizationData();
        BotSkinCustomizationData = new SkinCustomizationData();
        PlayerRating = 1000;
        Money = 0;
    }
}
