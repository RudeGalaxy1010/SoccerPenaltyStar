using UnityEngine;

public class Player : MonoBehaviour
{
    private Score _score;
    private PlayerMove _move;
    private PlayerRotation _rotation;

    public Score Score => _score;

    public void Construct(Score score, Controls controls, Transform ballTransform, Vector3 offsetFromBall)
    {
        _score = score;
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
