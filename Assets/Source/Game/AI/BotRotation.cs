using UnityEngine;

public class BotRotation : MonoBehaviour
{
    private const float MinAngle = 0;
    private const float MaxAngle = 360;

    private Transform _botTransform;
    private Transform _ballTransform;

    public void Construct(Transform botTransform, Transform ballTransform)
    {
        _botTransform = botTransform;
        _ballTransform = ballTransform;
    }

    public void RotateRandom()
    {
        float angle = GetRandomAngle();
        _botTransform.RotateAround(_ballTransform.position, Vector3.up, angle);
    }

    private float GetRandomAngle()
    {
        return Random.Range(MinAngle, MaxAngle);
    }
}
