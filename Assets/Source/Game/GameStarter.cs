using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private readonly float Time = 30;
    private readonly Vector3 BallOffset = new Vector3(0, 0, 1);
    // TODO: remove temp const
    private const int CurrentRating = 0;

    [Header("Common")]
    [SerializeField] private EndGame _endGame;
    [SerializeField] private ReverseTimer _reverseTimer;
    [SerializeField] private GoalSign _goalSign;
    [SerializeField] private WinnerDisplayer _winnerDisplayer;

    [Header("Player")]
    [SerializeField] private SmoothFollow _smoothFollow;
    [SerializeField] private ForceArrow _forceArrow;
    [SerializeField] private ScoreCounter _playerScoreCounter;

    [Header("Bot")]
    [SerializeField] private ScoreCounter _botScoreCounter;

    private Pause _pause;

    private void Start()
    {
        LoadData();

        _pause = new Pause();
        Controls controls = InitInput();
        Map map = InitMap(GamePrefabs.MapPrefabs, GamePrefabs.GatesPrefab, GamePrefabs.BonusGatesPrefab, _pause);

        Score playerScore = new Score();
        Score botScore = new Score();

        ActualPlayer player = InitPlayer(GamePrefabs.SkinPrefab, playerScore, controls, map, _pause);
        Bot bot = InitBot(botScore, map, _pause);

        _endGame.Construct(playerScore, botScore, _pause);
        _reverseTimer.Construct(Time);
        _goalSign.Construct(map.Gates, map.BonusGates);
        _winnerDisplayer.Construct(playerScore, botScore, player.Star, bot.Star);
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
        Ball ball = Create(GamePrefabs.BallPrefab, map.PlayerSpawnPosition + BallOffset);
        ActualPlayer player = Create(GamePrefabs.PlayerPrefab, map.PlayerSpawnPosition);
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
        Ball ball = Create(GamePrefabs.BallPrefab, map.BotSpawnPosition + BallOffset);
        Bot bot = Create(GamePrefabs.BotPrefab, map.BotSpawnPosition);
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
