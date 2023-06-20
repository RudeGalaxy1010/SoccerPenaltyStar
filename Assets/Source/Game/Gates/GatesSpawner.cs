using UnityEngine;

public class GatesSpawner : MonoBehaviour
{
    private const float MinGatesRotationAngle = 0f;
    private const float MaxGatesRotationAngle = 359f;

    private Gates _gates;
    private GatesPoint[] _gatesPoints;
    private GatesPoint _lastGatesPoint;

    public void Construct(Gates gatesPrefab, GatesPoint[] gatesSpawnPoints)
    {
        _gatesPoints = gatesSpawnPoints;
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
        gates.Reset();
    }

    private Vector3 GetRandomGatesPosition()
    {
        GatesPoint newPoint = _lastGatesPoint;

        while (newPoint == null || newPoint.IsBusy == true)
        {
            newPoint = _gatesPoints[Random.Range(0, _gatesPoints.Length)];
        }

        if (_lastGatesPoint != null)
        {
            _lastGatesPoint.IsBusy = false;
        }

        _lastGatesPoint = newPoint;
        newPoint.IsBusy = true;
        return newPoint.transform.position;
    }

    private Quaternion GetRandomGatesRotation()
    {
        return Quaternion.Euler(0, Random.Range(MinGatesRotationAngle, MaxGatesRotationAngle), 0);
    }

    public void OnDisable()
    {
        if (_gates != null)
        {
            _gates.GoalScored -= OnGoalScored;
        }
    }
}
