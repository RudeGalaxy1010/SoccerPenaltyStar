using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _botSpawnPoint;
    [SerializeField] private Transform[] _gatesSpawnPoints;
    [SerializeField] private GatesSpawner _gatesSpawner;
    [SerializeField] private BonusGatesSpawner _bonusGatesSpawner;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Vector3 BotSpawnPosition => _botSpawnPoint.position;

    public void Construct(Gates gatesPrefab, BonusGates bonusGatesPrefab, Pause pause)
    {
        _gatesSpawner.Construct(gatesPrefab, _gatesSpawnPoints);
        _bonusGatesSpawner.Construct(bonusGatesPrefab, _gatesSpawner.Gates.transform, pause, _gatesSpawnPoints);
    }
}
