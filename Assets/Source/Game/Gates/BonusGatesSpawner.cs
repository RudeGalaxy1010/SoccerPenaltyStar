using UnityEngine;

public class BonusGatesSpawner : MonoBehaviour
{
    private const float GatesActiveTime = 10f;
    private const float MinTimeToSpawnGates = 5f;
    private const float MaxTimeToSpawnGates = 10f;

    [SerializeField] private GatesSpawner _gatesSpawner;

    private BonusGates _bonusGates;
    private float _timer;
    private float _timeToSpawn;

    public void Construct(BonusGates gatesPrefab, GatesPoint[] gatesSpawnPoints, Pause pause)
    {
        _gatesSpawner.Construct(gatesPrefab.Gates, gatesSpawnPoints);
        _bonusGates = _gatesSpawner.Gates.GetComponent<BonusGates>();
        _bonusGates.Gates.GoalScored += OnGoalScored;
        _bonusGates.Timer.Expired += OnGatesTimerExpired;

        _timer = 0;
        _timeToSpawn = GetRandomTimeToSpawn();
        _bonusGates.gameObject.SetActive(false);
        pause.Add(_bonusGates.Timer);
    }

    public Gates Gates => _gatesSpawner.Gates;
    private bool IsGatesActive => _gatesSpawner.Gates.gameObject.activeInHierarchy == true;
    private float SkinTimeDecrease => DataHolder.PlayerLuck / 2f;

    private void Update()
    {
        if (_bonusGates != null && IsGatesActive == true)
        {
            return;
        }

        if (_timer >= _timeToSpawn)
        {
            _timer = 0;
            _bonusGates.gameObject.SetActive(true);
            _bonusGates.Timer.Construct(GatesActiveTime);
            _bonusGates.Gates.Reset();
        }

        _timer += Time.deltaTime;
    }

    private void OnGoalScored(Gates gates)
    {
        _bonusGates.gameObject.SetActive(false);
    }

    private void OnGatesTimerExpired()
    {
        _timeToSpawn = GetRandomTimeToSpawn();
        _bonusGates.gameObject.SetActive(false);
    }

    private float GetRandomTimeToSpawn()
    {
        return Random.Range(MinTimeToSpawnGates - SkinTimeDecrease, MaxTimeToSpawnGates - SkinTimeDecrease);
    }

    private void OnDestroy()
    {
        if (_bonusGates != null && _bonusGates.Gates != null)
        {
            _bonusGates.Gates.GoalScored -= OnGoalScored;
        }
    }
}
