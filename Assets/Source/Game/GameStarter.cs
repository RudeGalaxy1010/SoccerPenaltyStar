using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private const string SkinPrefabsPath = "SkinPrefabs/Skin";
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const string BallPrefabPath = "BallPrefabs/Ball";
    private const string PlayerPrefabPath = "PlayerPrefabs/Player";
    private const string BotPrefabPath = "BotPrefabs/Bot";
    private const string GatesPrefabPath = "GatePrefabs/Gates";
    private const string BonusGatesPrefabPath = "GatePrefabs/BonusGates";

    private readonly float Time = 30;
    private readonly Vector3 BallOffset = new Vector3(0, 0, 1);
    // TODO: remove temp const
    private const int CurrentRating = 0;

    [Header("Common")]
    [SerializeField] private EndGame _endGame;
    [SerializeField] private ReverseTimer _reverseTimer;

    [Header("Player")]
    [SerializeField] private SmoothFollow _smoothFollow;
    [SerializeField] private ForceArrow _forceArrow;
    [SerializeField] private ScoreCounter _playerScoreCounter;

    [Header("Bot")]
    [SerializeField] private ScoreCounter _botScoreCounter;

    // Resources
    private SkinCustomization _skinPrefab;
    private Ball _ballPrefab;
    private Map[] _mapPrefabs;
    private ActualPlayer _playerPrefab;
    private Bot _botPrefab;
    private Gates _gatesPrefab;
    private BonusGates _bonusGatesPrefab;

    private Pause _pause;

    private void Start()
    {
        LoadData();
        LoadResources();

        _pause = new Pause();
        Controls controls = InitInput();
        Map map = InitMap(_mapPrefabs, _gatesPrefab, _bonusGatesPrefab, _pause);

        Score playerScore = new Score();
        Score botScore = new Score();

        InitPlayer(_skinPrefab, playerScore, controls, map, _pause);
        InitBot(botScore, map, _pause);
        
        _endGame.Construct(playerScore, botScore, _pause);
        _reverseTimer.Construct(Time);
    }

    private void LoadData()
    {
        if (DataHolder.PlayerData != null)
        {
            return;
        }

        DataSaveLoad dataSaveLoad = new DataSaveLoad();
        dataSaveLoad.LoadData();
    }

    private void LoadResources()
    {
        _skinPrefab = Resources.Load<SkinCustomization>(SkinPrefabsPath);
        _mapPrefabs = Resources.LoadAll<Map>(MapPrefabsFolderPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
        _playerPrefab = Resources.Load<ActualPlayer>(PlayerPrefabPath);
        _botPrefab = Resources.Load<Bot>(BotPrefabPath);
        _gatesPrefab = Resources.Load<Gates>(GatesPrefabPath);
        _bonusGatesPrefab = Resources.Load<BonusGates>(BonusGatesPrefabPath);
    }

    private Controls InitInput()
    {
        Controls controls = new Controls();
        controls.Enable();
        return controls;
    }

    private Map InitMap(Map[] mapPrefabs, Gates gatesPrefab, BonusGates bonusGatesPrefab, Pause pause)
    {
        MapPicker mapPicker = new MapPicker();
        Map mapPrefab = mapPicker.GetMapPrefab(mapPrefabs, CurrentRating);
        Map map = Instantiate(mapPrefab);
        map.Construct(gatesPrefab, bonusGatesPrefab, pause);
        return map;
    }

    private ActualPlayer InitPlayer(SkinCustomization skinPrefab, Score score, Controls controls, Map map, Pause pause)
    {
        Ball ball = Create(_ballPrefab, map.PlayerSpawnPosition + BallOffset);
        ActualPlayer player = Create(_playerPrefab, map.PlayerSpawnPosition);
        player.Construct(skinPrefab, score, controls, ball.transform, -BallOffset);
        PlayerBallLauncher ballLauncher = new PlayerBallLauncher(player, ball, controls);

        _smoothFollow.SetTarget(ball.transform);
        _forceArrow.Construct(player.transform, ballLauncher);
        _playerScoreCounter.Construct(score);
        ball.SetOwner(player);
        pause.Add(player, ball, ballLauncher);

        return player;
    }

    private Bot InitBot(Score score, Map map, Pause pause)
    {
        Ball ball = Create(_ballPrefab, map.BotSpawnPosition + BallOffset);
        Bot bot = Create(_botPrefab, map.BotSpawnPosition);
        bot.Construct(score, ball.transform, -BallOffset);
        BotBallLauncher botBallLauncher = new BotBallLauncher(bot, ball);

        _botScoreCounter.Construct(score);
        ball.SetOwner(bot);
        pause.Add(bot, ball);

        return bot;
    }

    private T Create<T>(T prefab, Vector3 position)
        where T : MonoBehaviour
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }
}
