using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const int SwitchSideAngle = 180;
    private const float Speed = 180f;

    private Transform _playerTransform;
    private Transform _ballTransform;
    private Controls _controls;
    private bool _isHolding;

    public void Construct(Controls controls, Transform playerTransform, Transform ballTransform)
    {
        _controls = controls;
        _playerTransform = playerTransform;
        _ballTransform = ballTransform;
    }

    private void Update()
    {
        if (_isHolding == false)
        {
            return;
        }

        float delta = -_controls.DefaultMap.DeltaX.ReadValue<float>();
        _playerTransform.transform.RotateAround(_ballTransform.position, Vector3.up, Speed * delta * Time.deltaTime);
        Vector3 lookDirection = _ballTransform.position;
        lookDirection.y = transform.position.y;
        _playerTransform.LookAt(lookDirection);
    }

    public void SwitchRotationSide()
    {
        _playerTransform.transform.RotateAround(_ballTransform.position, Vector3.up, SwitchSideAngle);
    }

    public void Enable()
    {
        _isHolding = true;
    }

    public void Disable()
    {
        _isHolding = false;
    }
}
