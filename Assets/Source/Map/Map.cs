using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _botSpawnPoint;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Vector3 BotSpawnPosition => _botSpawnPoint.position;
}
