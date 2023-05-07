using System;
using System.Collections;
using UnityEngine;

public class Bot : Player, IPauseable
{
    private const float MinWaitingTime = 1f;
    private const float MaxWaitingTime = 2f;

    public event Action LaunchNeeded;

    private PlayerMove _move;
    private BotRotation _rotation;
    private Coroutine _makeLaunchesCoroutine;

    public void Construct(Skin skinPrefab, Score score, Transform ballTransform, 
        Transform gatesTransform, Vector3 offsetFromBall)
    {
        Construct(score, skinPrefab, DataHolder.PlayerData.BotSkinData);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
        _rotation = GetComponent<BotRotation>();
        _rotation.Construct(transform, ballTransform, gatesTransform);

        StartMakeLaunches();
    }

    public void TeleportToBall()
    {
        _move.TeleportToBall();
    }

    public void MakeRotation()
    {
        _rotation.Rotate();
    }

    private void StartMakeLaunches()
    {
        _makeLaunchesCoroutine = StartCoroutine(MakeLaunches());
    }
    
    private IEnumerator MakeLaunches()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomWaitingTime());
            LaunchNeeded?.Invoke();
        }
    }

    private float GetRandomWaitingTime()
    {
        return UnityEngine.Random.Range(MinWaitingTime, MaxWaitingTime);
    }

    public void Pause()
    {
        if (_makeLaunchesCoroutine != null)
        {
            StopCoroutine(_makeLaunchesCoroutine);
        }
    }

    public void Resume()
    {
        StartMakeLaunches();
    }
}
