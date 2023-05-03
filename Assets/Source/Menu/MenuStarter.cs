using System;
using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [SerializeField] private Transform _skinSpawnPoint;
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private LevelButtons _levelButtons;

    private DataSaveLoad _dataSaveLoad;

    private void Start()
    {
        InitData();
        InitLevel();
        InitSkins();
    }

    private void InitData()
    {
        _dataSaveLoad = new DataSaveLoad();
        _dataSaveLoad.LoadData();
    }

    private void InitLevel()
    {
        LevelLoader levelLoader = new LevelLoader();
        _levelButtons.Construct(levelLoader);
    }

    private void InitSkins()
    {
        SkinPicker skinPicker = new SkinPicker();
        skinPicker.Construct(_skinSpawnPoint);
        _skinButtons.Construct(skinPicker);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
