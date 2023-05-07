using TMPro;
using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private Transform _playerSkinSpawnPoint;
    [SerializeField] private Transform _botSkinSpawnPoint;
    [SerializeField] private MatchMaker _matchMaker;
    [SerializeField] private BotSelector _botSelector;
    [SerializeField] private TMP_Text _botNickText;
    [SerializeField] private RatingDisplay _ratingDisplay;
    [SerializeField] private MoneyDisplay _moneyDisplay;
    [SerializeField] private SkinStatsDisplay _skinStatsDisplay;

    [Header("Buttons")]
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private PurchaseButton _purchaseButton;
    [SerializeField] private LevelButtons _levelButtons;

    private DataSaveLoad _dataSaveLoad;
    private Money _money;

    private void Start()
    {
        LoadData();
        InitMatchMaking(_matchMaker, _botSelector, _botSkinSpawnPoint, _botNickText, _ratingDisplay);
        InitMoney();
        InitPlayerSkin(GamePrefabs.SkinPrefab, _playerSkinSpawnPoint, _money);
        _ratingDisplay.DisplayPlayerRating(DataHolder.PlayerData.PlayerRating);
    }

    private void LoadData()
    {
        _dataSaveLoad = new DataSaveLoad();
        _dataSaveLoad.LoadData();
    }

    private void InitMatchMaking(MatchMaker matchMaker, BotSelector botSelector, 
        Transform botSkinSpawnPoint, TMP_Text botNickText, RatingDisplay ratingDisplay)
    {
        LevelLoader levelLoader = new LevelLoader();
        botSelector.Construct(botSkinSpawnPoint, botNickText, ratingDisplay);
        matchMaker.Construct(botSelector, levelLoader);
    }

    private void InitPlayerSkin(Skin skinPrefab, Transform spawnPoint, Money money)
    {
        Skin skin = Instantiate(skinPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        skin.Apply(DataHolder.PlayerData.PlayerSkinData);
        PlayerSkinSaver playerSkinSaver = new PlayerSkinSaver(skin);
        SkinPartsUnlocker skinPartsUnlocker = new SkinPartsUnlocker();
        skinPartsUnlocker.Construct(skin, money, DataHolder.PlayerData.UnlockedParts);
        _purchaseButton.Construct(skinPartsUnlocker);
        _skinButtons.Construct(skin);
        _levelButtons.Construct(skinPartsUnlocker);
        _skinStatsDisplay.Construct(skin);
    }

    private void InitMoney()
    {
        _money = new Money();
        _moneyDisplay.Construct(_money);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
