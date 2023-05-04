using UnityEngine;

public class GatesSpawner : MonoBehaviour
{
    private const float MinGatesRotationAngle = 0f;
    private const float MaxGatesRotationAngle = 359f;

    private Transform[] _gatesSpawnPoints;
    private Gates _gates;
    private Vector3 _lastGatesPosition;

    public void Construct(Gates gatesPrefab, Transform[] gatesSpawnPoints)
    {
        _gatesSpawnPoints = gatesSpawnPoints;
        _gates = Instantiate(gatesPrefab);
        _gates.GoalScored += OnGoalScored;
        MoveGates(_gates);
    }

    public Gates Gates => _gates;

    private void OnGoalScored(Gates gates)
    {
        MoveGates(gates);
    }

    private void MoveGates(Gates gates)
    {
        gates.transform.position = GetRandomGatesPosition();
        gates.transform.rotation = GetRandomGatesRotation();
    }

    private Vector3 GetRandomGatesPosition()
    {
        Vector3 newPosition = _lastGatesPosition;

        while (newPosition == _lastGatesPosition)
        {
            newPosition = _gatesSpawnPoints[UnityEngine.Random.Range(0, _gatesSpawnPoints.Length)].position;
        }

        _lastGatesPosition = newPosition;
        return newPosition;
    }

    private Quaternion GetRandomGatesRotation()
    {
        return Quaternion.Euler(0, UnityEngine.Random.Range(MinGatesRotationAngle, MaxGatesRotationAngle), 0);
    }

    public void OnDisable()
    {
        if (_gates != null)
        {
            _gates.GoalScored -= OnGoalScored;
        }
    }
}
