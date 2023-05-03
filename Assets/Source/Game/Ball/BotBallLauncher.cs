using System;
using UnityEngine;

public class BotBallLauncher : BallLauncher, IDisposable
{
    private const float MinDelta = 3;
    private const float MaxDelta = 7;

    private Bot _bot;

    public BotBallLauncher(Bot bot, Ball ball) : base(bot, ball)
    {
        _bot = bot;
        _bot.LaunchNeeded += OnLaunchNeeded;
    }

    private void OnLaunchNeeded()
    {
        PrepareLaunch();
        Launch();
    }

    protected override float GetDelta()
    {
        return UnityEngine.Random.Range(MinDelta, MaxDelta);
    }

    public override void PrepareLaunch()
    {
        _bot.TeleportToBall();
        _bot.MakeRotation();
    }

    public override void Launch()
    {
        float delta = GetDelta();
        Vector3 force = GetForce(delta);
        Ball.AddForce(force);
    }

    public void Dispose()
    {
        _bot.LaunchNeeded -= OnLaunchNeeded;
    }
}
