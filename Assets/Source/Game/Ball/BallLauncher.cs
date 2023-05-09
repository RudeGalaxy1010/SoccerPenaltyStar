using UnityEngine;

public abstract class BallLauncher
{
    public const float MinForce = -10f;
    public const float MaxForce = 10f;
    public const float ForceScale = 5f;

    protected Player Player;
    protected Ball Ball;

    public BallLauncher(Player player, Ball ball)
    {
        Player = player;
        Ball = ball;
    }

    protected abstract float GetDelta();
    public abstract void PrepareLaunch();
    public abstract void Launch();

    protected Vector3 GetForce(float delta)
    {
        Vector3 forceDirection = GetNormalizedForceDirection();
        Vector3 rawForce = forceDirection;
        float clampedDelta = Mathf.Clamp(delta, MinForce, MaxForce);
        return rawForce * clampedDelta * ForceScale;
    }

    protected Vector3 GetNormalizedForceDirection()
    {
        Vector2 ballFlatPosition = new Vector3(Ball.transform.position.x, Ball.transform.position.z);
        Vector2 playerFlatPosition = new Vector3(Player.transform.position.x, Player.transform.position.z);
        Vector2 forceDirection = ballFlatPosition - playerFlatPosition;
        return new Vector3(forceDirection.x, 0, forceDirection.y).normalized;
    }
}
