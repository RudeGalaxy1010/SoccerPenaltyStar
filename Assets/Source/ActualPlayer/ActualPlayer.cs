using UnityEngine;

public class ActualPlayer : Player
{
    private PlayerMove _move;
    private PlayerRotation _rotation;

    public void Construct(Score score, Controls controls, Transform ballTransform, Vector3 offsetFromBall)
    {
        Construct(score);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
        _rotation = GetComponent<PlayerRotation>();
        _rotation.Construct(controls, transform, ballTransform);
    }

    public void TeleportToBall()
    {
        _move.TeleportToBall();
    }

    public void EnableRotation()
    {
        _rotation.Enable();
    }

    public void DisableRotation()
    {
        _rotation.Disable();
    }
}
