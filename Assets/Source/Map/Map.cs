using System;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const float MinGatesRotationAngle = 0f;
    private const float MaxGatesRotationAngle = 359f;

    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _botSpawnPoint;
    [SerializeField] private Transform[] _gatesSpawnPoints;

    private Gates _gates;
    private Vector3 _lastPosition;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Vector3 BotSpawnPosition => _botSpawnPoint.position;

    public void Construct(Gates gatesPrefab)
    {
        _gates = Instantiate(gatesPrefab);
        _gates.GoalScored += OnGoalScored;
        MoveGates(_gates);
    }

    private void OnDestroy()
    {
        if (_gates != null )
        {
            _gates.GoalScored -= OnGoalScored;
        }
    }

    private void MoveGates(Gates gates)
    {
        gates.transform.position = GetRandomGatesPosition();
        gates.transform.rotation = GetRandomGatesRotation();
    }

    private void OnGoalScored(Gates gates)
    {
        MoveGates(gates);
    }

    private Vector3 GetRandomGatesPosition()
    {
        Vector3 newPosition = _lastPosition;

        while (newPosition == _lastPosition)
        {
            newPosition = _gatesSpawnPoints[UnityEngine.Random.Range(0, _gatesSpawnPoints.Length)].position;
        }

        _lastPosition = newPosition;
        return newPosition;
    }

    private Quaternion GetRandomGatesRotation()
    {
        return Quaternion.Euler(0, UnityEngine.Random.Range(MinGatesRotationAngle, MaxGatesRotationAngle), 0);
    }
}
