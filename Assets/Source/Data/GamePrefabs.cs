using UnityEngine;

public static class GamePrefabs
{
    private const string SkinPrefabsPath = "SkinPrefabs/Skin";
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const string BallPrefabPath = "BallPrefabs/Ball";
    private const string PlayerPrefabPath = "PlayerPrefabs/Player";
    private const string BotPrefabPath = "BotPrefabs/Bot";
    private const string GatesPrefabPath = "GatePrefabs/Gates";
    private const string BonusGatesPrefabPath = "GatePrefabs/BonusGates";
    private const string ShopItemPrefabPath = "ShopItems/ShopItem";

    private static Skin _skinPrefab;
    private static Ball _ballPrefab;
    private static Map[] _mapPrefabs;
    private static ActualPlayer _playerPrefab;
    private static Bot _botPrefab;
    private static Gates _gatesPrefab;
    private static BonusGates _bonusGatesPrefab;
    private static ShopItemView _shopItemViewPrefab;

    public static Skin SkinPrefab => _skinPrefab;
    public static Ball BallPrefab => _ballPrefab;
    public static Map[] MapPrefabs => _mapPrefabs;
    public static ActualPlayer PlayerPrefab => _playerPrefab;
    public static Bot BotPrefab => _botPrefab;
    public static Gates GatesPrefab => _gatesPrefab;
    public static BonusGates BonusGatesPrefab => _bonusGatesPrefab;
    public static ShopItemView ShopItemViewPrefab => _shopItemViewPrefab;

    static GamePrefabs()
    {
        _skinPrefab = Resources.Load<Skin>(SkinPrefabsPath);
        _mapPrefabs = Resources.LoadAll<Map>(MapPrefabsFolderPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
        _playerPrefab = Resources.Load<ActualPlayer>(PlayerPrefabPath);
        _botPrefab = Resources.Load<Bot>(BotPrefabPath);
        _gatesPrefab = Resources.Load<Gates>(GatesPrefabPath);
        _bonusGatesPrefab = Resources.Load<BonusGates>(BonusGatesPrefabPath);
        _shopItemViewPrefab = Resources.Load<ShopItemView>(ShopItemPrefabPath);
    }
}
