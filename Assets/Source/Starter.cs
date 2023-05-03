using UnityEngine;

public class Starter : MonoBehaviour
{
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const string BallPrefabPath = "BallPrefabs/Ball";
    private const string PlayerPrefabPath = "PlayerPrefabs/Player";
    private const string BotPrefabPath = "BotPrefabs/Bot";
    private const string GatesPrefabPath = "GatePrefabs/Gates";

    private readonly float Time = 10;
    private readonly Vector3 BallOffset = new Vector3(0, 0, 1);

    // TODO: remove temp const
    private const int CurrentRating = 0;

    [Header("Common")]
    [SerializeField] private ReverseTimer _reverseTimer;

    [Header("Player")]
    [SerializeField] private SmoothFollow _smoothFollow;
    [SerializeField] private ForceArrow _forceArrow;
    [SerializeField] private ScoreCounter _playerScoreCounter;

    [Header("Bot")]
    [SerializeField] private ScoreCounter _botScoreCounter;

    // Resources
    private Ball _ballPrefab;
    private Map[] _mapPrefabs;
    private ActualPlayer _playerPrefab;
    private Bot _botPrefab;
    private Gates _gatesPrefab;

    private void Start()
    {
        LoadResources();

        Controls controls = InitInput();
        Map map = InitMap(_mapPrefabs, _gatesPrefab);

        InitPlayer(controls, map);
        InitBot(map);

        _reverseTimer.Construct(Time);
    }

    private void LoadResources()
    {
        _mapPrefabs = Resources.LoadAll<Map>(MapPrefabsFolderPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
        _playerPrefab = Resources.Load<ActualPlayer>(PlayerPrefabPath);
        _botPrefab = Resources.Load<Bot>(BotPrefabPath);
        _gatesPrefab = Resources.Load<Gates>(GatesPrefabPath);
    }

    private Controls InitInput()
    {
        Controls controls = new Controls();
        controls.Enable();
        return controls;
    }

    private Map InitMap(Map[] mapPrefabs, Gates gatesPrefab)
    {
        MapPicker mapPicker = new MapPicker();
        Map mapPrefab = mapPicker.GetMapPrefab(mapPrefabs, CurrentRating);
        Map map = Instantiate(mapPrefab);
        map.Construct(gatesPrefab);
        return map;
    }

    private void InitPlayer(Controls controls, Map map)
    {
        Ball ball = Create(_ballPrefab, map.PlayerSpawnPosition + BallOffset);
        ActualPlayer player = Create(_playerPrefab, map.PlayerSpawnPosition);
        Score score = new Score();
        player.Construct(score, controls, ball.transform, -BallOffset);
        PlayerBallLauncher ballLauncher = new PlayerBallLauncher(player, ball, controls);

        _smoothFollow.SetTarget(ball.transform);
        _forceArrow.Construct(player.transform, ballLauncher);
        _playerScoreCounter.Construct(score);
        ball.SetOwner(player);
    }

    private void InitBot(Map map)
    {
        Ball ball = Create(_ballPrefab, map.BotSpawnPosition + BallOffset);
        Bot bot = Create(_botPrefab, map.BotSpawnPosition);
        Score score = new Score();
        bot.Construct(score, ball.transform, -BallOffset);
        BotBallLauncher botBallLauncher = new BotBallLauncher(bot, ball);

        _botScoreCounter.Construct(score);
        ball.SetOwner(bot);
    }

    private T Create<T>(T prefab, Vector3 position)
        where T : MonoBehaviour
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }
}
