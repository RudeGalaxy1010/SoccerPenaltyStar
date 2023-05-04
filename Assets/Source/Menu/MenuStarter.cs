using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    private const string SkinPrefabsPath = "SkinPrefabs/Skin";

    [SerializeField] private Transform _skinSpawnPoint;
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private LevelButtons _levelButtons;

    // Resources
    private SkinCustomization _skinPrefab;

    private DataSaveLoad _dataSaveLoad;

    private void Start()
    {
        LoadResources();
        LoadData();

        InitLevel();
        InitSkins(_skinPrefab, _skinSpawnPoint);
    }

    private void LoadResources()
    {
        _skinPrefab = Resources.Load<SkinCustomization>(SkinPrefabsPath);
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
        skin.Apply(DataHolder.PlayerData.SkinCustomizationData);
        _skinButtons.Construct(skin);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
