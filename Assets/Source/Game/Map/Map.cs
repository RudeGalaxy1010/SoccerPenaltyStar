using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _botSpawnPoint;
    [SerializeField] private GatesPoint[] _gatesSpawnPoints;
    [SerializeField] private GatesSpawner _gatesSpawner;
    [SerializeField] private BonusGatesSpawner _bonusGatesSpawner;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Vector3 BotSpawnPosition => _botSpawnPoint.position;
    public Gates Gates => _gatesSpawner.Gates;
    public Gates BonusGates => _bonusGatesSpawner.Gates;

    public void Construct(Gates gatesPrefab, BonusGates bonusGatesPrefab, Pause pause)
    {
        _gatesSpawner.Construct(gatesPrefab, _gatesSpawnPoints);
        _bonusGatesSpawner.Construct(bonusGatesPrefab, _gatesSpawnPoints, pause);
    }
}
