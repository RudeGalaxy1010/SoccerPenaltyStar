using UnityEngine;

public class Starter : MonoBehaviour
{
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const string BallPrefabPath = "BallPrefabs/Ball";
    private const string PlayerPrefabPath = "PlayerPrefabs/Player";

    [SerializeField] private SmoothFollow _smoothFollow;
    [SerializeField] private Vector3 _ballSpawnOffset;

    private DefaultControls _defaultControls;
    private MapPicker _mapPicker;
    private PlayerSpawner _playerSpawner;

    private Ball _ballPrefab;
    private Map[] _mapPrefabs;
    private Player _playerPrefab;

    private void Start()
    {
        LoadResources();
        InitInput();
        Map map = InitMap(_mapPrefabs);
        Player player = InitPlayer(map, _playerPrefab, _ballPrefab);
        _smoothFollow.SetTarget(player.Ball.transform);
    }

    private void LoadResources()
    {
        _mapPrefabs = Resources.LoadAll<Map>(MapPrefabsFolderPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
        _playerPrefab = Resources.Load<Player>(PlayerPrefabPath);
    }

    private void InitInput()
    {
        _defaultControls = new DefaultControls();
        _defaultControls.Enable();
    }

    private Map InitMap(Map[] mapPrefabs)
    {
        _mapPicker = new MapPicker(mapPrefabs);
        return _mapPicker.CreateMap(0);
    }

    private Player InitPlayer(Map map, Player playerPrefab, Ball ballPrefab)
    {
        _playerSpawner = new PlayerSpawner(_ballSpawnOffset);
        Player player = _playerSpawner.CreatePlayer(map, playerPrefab);
        Ball ball = _playerSpawner.CreateBall(player.transform.position, ballPrefab);
        player.Construct(ball, _defaultControls);
        return player;
    }
}
