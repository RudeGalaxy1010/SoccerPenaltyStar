using UnityEngine;

public class Starter : MonoBehaviour
{
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const string BallPrefabPath = "BallPrefabs/Ball";
    private const string PlayerPrefabPath = "PlayerPrefabs/Player";
    private const string GatesPrefabPath = "GatePrefabs/Gates";

    private readonly Vector3 BallOffset = new Vector3(0, 0, 1);

    // TODO: remove temp const
    private const int CurrentRating = 0;

    [SerializeField] private SmoothFollow _smoothFollow;
    [SerializeField] private ForceArrow _forceArrow;
    [SerializeField] private ScoreCounter _playerScoreCounter;

    // Resources
    private Ball _ballPrefab;
    private Map[] _mapPrefabs;
    private Player _playerPrefab;
    private Gates _gatesPrefab;

    private void Start()
    {
        LoadResources();

        Controls controls = InitInput();
        Map map = InitMap(_mapPrefabs, _gatesPrefab);
        Ball ball = CreateBall(_ballPrefab, map.PlayerSpawnPosition + BallOffset);
        Player player = CreatePlayer(_playerPrefab, map.PlayerSpawnPosition);
        InitPlayer(player, new Score(), controls, ball.transform, -BallOffset);
        BallLauncher ballLauncher = new BallLauncher(controls, player, ball);

        _smoothFollow.SetTarget(ball.transform);
        _forceArrow.Construct(player.transform, ballLauncher);
        _playerScoreCounter.Construct(player.Score);
        ball.SetOwner(player);
    }

    private void LoadResources()
    {
        _mapPrefabs = Resources.LoadAll<Map>(MapPrefabsFolderPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
        _playerPrefab = Resources.Load<Player>(PlayerPrefabPath);
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

    private Ball CreateBall(Ball ballPrefab, Vector3 position)
    {
        return Instantiate(ballPrefab, position, Quaternion.identity);
    }

    private Player CreatePlayer(Player playerPrefab, Vector3 position)
    {
        return Instantiate(playerPrefab, position, Quaternion.identity);
    }

    private void InitPlayer(Player player, Score score, Controls controls, Transform ballTransform, Vector3 offsetFromBall)
    {
        player.Construct(score, controls, ballTransform, offsetFromBall);
    }
}
