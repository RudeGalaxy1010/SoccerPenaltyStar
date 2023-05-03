using UnityEngine;

public static class PlayerDataExtensions
{
    public static string ToJson(this PlayerData playerData)
    {
        return JsonUtility.ToJson(playerData);
    }

    public static PlayerData FromJson(this PlayerData playerData, string data)
    {
        PlayerData newPlayerData = JsonUtility.FromJson<PlayerData>(data);
        return newPlayerData;
    }
}
