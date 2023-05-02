using System;
using UnityEngine;

public class Map : MonoBehaviour
{
    public event Action Passed;

    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _botSpawnPoint;
    [SerializeField] private Transform[] _gatesSpawnPoints;

    private Gates _gates;
    private int _currentGatesPointIndex;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Vector3 BotSpawnPosition => _botSpawnPoint.position;

    public void Construct(Gates gatesPrefab)
    {
        _currentGatesPointIndex = 0;
        _gates = CreateGates(gatesPrefab, _gatesSpawnPoints[_currentGatesPointIndex].position);
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

    private Gates CreateGates(Gates gatesPrefab, Vector3 position)
    {
        return Instantiate(gatesPrefab, position, Quaternion.identity);
    }

    private void MoveGates(Gates gates)
    {
        if (_currentGatesPointIndex >= _gatesSpawnPoints.Length)
        {
            Passed?.Invoke();
            _gates.GoalScored -= OnGoalScored;
            Destroy(gates.gameObject);
            return;
        }

        gates.transform.position = _gatesSpawnPoints[_currentGatesPointIndex].position;
        gates.transform.rotation = _gatesSpawnPoints[_currentGatesPointIndex].rotation;
        _currentGatesPointIndex++;
    }

    private void OnGoalScored(Gates gates)
    {
        MoveGates(gates);
    }
}
