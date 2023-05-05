using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [SerializeField] private Transform _skinSpawnPoint;
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private LevelButtons _levelButtons;

    private DataSaveLoad _dataSaveLoad;

    private void Start()
    {
        LoadData();
        InitLevel();
        InitSkins(GamePrefabs.SkinPrefab, _skinSpawnPoint);
    }

    private void LoadData()
    {
        _dataSaveLoad = new DataSaveLoad();
        _dataSaveLoad.LoadData();
    }

    private void InitLevel()
    {
        LevelLoader levelLoader = new LevelLoader();
        _levelButtons.Construct(levelLoader);
    }

    private void InitSkins(SkinCustomization skinPrefab, Transform spawnPoint)
    {
        SkinCustomization skin = Instantiate(skinPrefab, spawnPoint.position, spawnPoint.rotation);
        skin.Apply(DataHolder.PlayerData.PlayerSkinCustomizationData);
        _skinButtons.Construct(skin);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
