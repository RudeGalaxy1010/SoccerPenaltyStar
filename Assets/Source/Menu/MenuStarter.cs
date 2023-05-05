using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private Transform _playerSkinSpawnPoint;
    [SerializeField] private Transform _botSkinSpawnPoint;
    [SerializeField] private MatchMaker _matchMaker;
    [SerializeField] private BotSelector _botSelector;

    [Header("Buttons")]
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private LevelButtons _levelButtons;

    private DataSaveLoad _dataSaveLoad;

    private void Start()
    {
        LoadData();
        InitMatchMaking(_matchMaker, _botSelector, _botSkinSpawnPoint);
        InitPlayerSkin(GamePrefabs.SkinPrefab, _playerSkinSpawnPoint);
    }

    private void LoadData()
    {
        _dataSaveLoad = new DataSaveLoad();
        _dataSaveLoad.LoadData();
    }

    private void InitMatchMaking(MatchMaker matchMaker, BotSelector botSelector, Transform botSkinSpawnPoint)
    {
        LevelLoader levelLoader = new LevelLoader();
        botSelector.Construct(botSkinSpawnPoint);
        matchMaker.Construct(botSelector, levelLoader);
    }

    private void InitPlayerSkin(SkinCustomization skinPrefab, Transform spawnPoint)
    {
        SkinCustomization skin = Instantiate(skinPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        skin.Apply(DataHolder.PlayerData.PlayerSkinCustomizationData);
        _skinButtons.Construct(skin);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
