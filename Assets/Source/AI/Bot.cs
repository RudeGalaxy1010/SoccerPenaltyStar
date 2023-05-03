using UnityEngine;

public class Bot : Player
{
    private PlayerMove _move;

    public void Construct(Score score, Transform ballTransform, Vector3 offsetFromBall)
    {
        Construct(score);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
    }
}
