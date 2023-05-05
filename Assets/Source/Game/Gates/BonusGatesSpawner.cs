using UnityEngine;

public class BonusGatesSpawner : MonoBehaviour
{
    private const float MinGatesRotationAngle = 0f;
    private const float MaxGatesRotationAngle = 359f;

    private const float GatesActiveTime = 10f;
    private const float MinTimeToSpawnGates = 5f;
    private const float MaxTimeToSpawnGates = 10f;

    private Transform[] _gatesSpawnPoints;
    private BonusGates _bonusGates;
    private Transform _gatesTransform;
    private Vector3 _lastGatesPosition;

    private float _timer;
    private float _timeToSpawn;

    public void Construct(BonusGates gatesPrefab, Transform gatesTransform, Pause pause, Transform[] gatesSpawnPoints)
    {
        _gatesSpawnPoints = gatesSpawnPoints;
        _gatesTransform = gatesTransform;
        _bonusGates = Instantiate(gatesPrefab);
        _bonusGates.Gates.GoalScored += OnGoalScored;
        _bonusGates.Timer.Expired += OnGatesTimerExpired;
        MoveGates(_bonusGates.Gates.transform);

        _timer = 0;
        _timeToSpawn = GetRandomTimeToSpawn();
        _bonusGates.gameObject.SetActive(false);
        pause.Add(_bonusGates.Timer);
    }

    public Gates Gates => _bonusGates.Gates;
    private bool IsGatesActive => _bonusGates.gameObject.activeInHierarchy == true;

    private void Update()
    {
        if (_bonusGates != null && IsGatesActive == true)
        {
            return;
        }

        if (_timer >= _timeToSpawn)
        {
            _timer = 0;
            MoveGates(_bonusGates.Gates.transform);
            _bonusGates.gameObject.SetActive(true);
            _bonusGates.Timer.Construct(GatesActiveTime);
        }

        _timer += Time.deltaTime;
    }

    private void OnGoalScored(Gates gates)
    {
        MoveGates(gates.transform);
    }

    private void MoveGates(Transform gates)
    {
        gates.position = GetRandomGatesPosition();
        gates.rotation = GetRandomGatesRotation();
    }

    private Vector3 GetRandomGatesPosition()
    {
        Vector3 newPosition = _lastGatesPosition;

        while (newPosition == _lastGatesPosition || newPosition == _gatesTransform.position)
        {
            newPosition = _gatesSpawnPoints[Random.Range(0, _gatesSpawnPoints.Length)].position;
        }

        _lastGatesPosition = newPosition;
        return newPosition;
    }

    private Quaternion GetRandomGatesRotation()
    {
        return Quaternion.Euler(0, Random.Range(MinGatesRotationAngle, MaxGatesRotationAngle), 0);
    }

    private void OnGatesTimerExpired()
    {
        _timeToSpawn = GetRandomTimeToSpawn();
        _bonusGates.gameObject.SetActive(false);
    }

    private float GetRandomTimeToSpawn()
    {
        return Random.Range(MinTimeToSpawnGates, MaxTimeToSpawnGates);
    }

    public void OnDisable()
    {
        if (_bonusGates != null && _bonusGates.Gates != null)
        {
            _bonusGates.Gates.GoalScored -= OnGoalScored;
        }
    }
}
