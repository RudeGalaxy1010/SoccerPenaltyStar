using UnityEngine;

public class BotRotation : MonoBehaviour
{
    private Transform _botTransform;
    private Transform _ballTransform;
    private Transform _gatesTransform;

    public void Construct(Transform botTransform, Transform ballTransform, Transform gatesTransform)
    {
        _botTransform = botTransform;
        _ballTransform = ballTransform;
        _gatesTransform = gatesTransform;
    }

    public void Rotate()
    {
        Vector3 gatesToBallDirection = _ballTransform.position - _gatesTransform.position;
        Vector3 ballToBotDirection = transform.position - _ballTransform.position;
        float angle = -Vector3.Angle(gatesToBallDirection, ballToBotDirection);
        _botTransform.RotateAround(_ballTransform.position, Vector3.up, angle);
    }
}
