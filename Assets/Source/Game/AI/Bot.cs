using System;
using System.Collections;
using UnityEngine;

public class Bot : Player, IPauseable
{
    private const float LaunchesRate = 0.3f;
    private const float Second = 1f;

    public event Action LaunchNeeded;

    private PlayerMove _move;
    private BotRotation _rotation;
    private Coroutine _makeLaunchesCoroutine;

    public void Construct(Score score, Transform ballTransform, Vector3 offsetFromBall)
    {
        Construct(score);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
        _rotation = GetComponent<BotRotation>();
        _rotation.Construct(transform, ballTransform);

        StartMakeLaunches();
    }

    public void TeleportToBall()
    {
        _move.TeleportToBall();
    }

    public void MakeRotation()
    {
        _rotation.RotateRandom();
    }

    private void StartMakeLaunches()
    {
        _makeLaunchesCoroutine = StartCoroutine(MakeLaunches(Second / LaunchesRate));
    }
    
    private IEnumerator MakeLaunches(float launchesDelay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(launchesDelay);

        while (true)
        {
            yield return waitForSeconds;
            LaunchNeeded?.Invoke();
        }
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
