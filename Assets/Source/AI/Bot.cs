using System;
using System.Collections;
using UnityEngine;

public class Bot : Player
{
    private const float LaunchesRate = 0.3f;
    private const float Second = 1f;

    public event Action LaunchNeeded;

    private PlayerMove _move;
    private BotRotation _rotation;

    public void Construct(Score score, Transform ballTransform, Vector3 offsetFromBall)
    {
        Construct(score);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
        _rotation = GetComponent<BotRotation>();
        _rotation.Construct(transform, ballTransform);

        StartCoroutine(MakeLaunches(Second / LaunchesRate));
    }

    public void TeleportToBall()
    {
        _move.TeleportToBall();
    }

    public void MakeRotation()
    {
        _rotation.RotateRandom();
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
}
