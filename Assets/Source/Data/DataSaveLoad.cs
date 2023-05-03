using UnityEngine;

public class DataSaveLoad
{
    private const string SavePath = "SPSsv";

    public void LoadData()
    {
        DataHolder.PlayerData = new PlayerData();
        string data = PlayerPrefs.GetString(SavePath, "");

        if (data != "")
        {
            DataHolder.PlayerData = DataHolder.PlayerData.FromJson(data);
        }
    }

    public void SaveData()
    {
        PlayerData playerData = DataHolder.PlayerData;
        string data = playerData.ToJson();
        PlayerPrefs.SetString(SavePath, data);
    }
}
