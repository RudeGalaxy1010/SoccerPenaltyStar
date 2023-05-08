using System;
using TMPro;
using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private Transform _playerSkinSpawnPoint;
    [SerializeField] private Transform _botSkinSpawnPoint;
    [SerializeField] private LevelButtons _levelButtons;

    [Header("Match Making")]
    [SerializeField] private MatchMaker _matchMaker;
    [SerializeField] private BotSelector _botSelector;
    [SerializeField] private TMP_Text _botNickText;
    [SerializeField] private RatingDisplay _ratingDisplay;

    [Header("Money")]
    [SerializeField] private MoneyDisplay _coinsDisplay;
    [SerializeField] private MoneyDisplay _dollarsDisplay;

    [Header("Customization")]
    [SerializeField] private SkinStatsDisplay _skinStatsDisplay;
    [SerializeField] private SkinButtons _skinButtons;
    [SerializeField] private PurchaseButton _purchaseButton;

    [Header("Shop")]
    [SerializeField] private Shop _coinsShop;
    [SerializeField] private Shop _dollarsShop;

    private DataSaveLoad _dataSaveLoad;
    private Coins _coins;
    private Dollars _dollars;

    private void Start()
    {
        LoadData();
        InitMatchMaking(_matchMaker, _botSelector, _botSkinSpawnPoint, _botNickText, _ratingDisplay);
        InitMoney();
        InitPlayerSkin(GamePrefabs.SkinPrefab, _playerSkinSpawnPoint, _coins);
        InitShop(GamePrefabs.ShopItemViewPrefab, _coins, _dollars);
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

    private void InitPlayerSkin(Skin skinPrefab, Transform spawnPoint, Coins money)
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
        _coins = new Coins();
        _coinsDisplay.Construct(_coins);
        _dollars = new Dollars();
        _dollarsDisplay.Construct(_dollars);
    }

    private void InitShop(ShopItemView shopItemViewPrefab, Coins coins, Dollars dollars)
    {
        _coinsShop.Construct(coins, shopItemViewPrefab);
        _dollarsShop.Construct(dollars, shopItemViewPrefab);
    }

    private void OnDestroy()
    {
        _dataSaveLoad.SaveData();
    }
}
