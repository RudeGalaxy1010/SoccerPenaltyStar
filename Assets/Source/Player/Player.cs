using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private const float RotationSpeed = 180f;

    private Ball _ball;
    private Vector3 _ballOffset;
    private DefaultControls _controls;

    private bool _isHoldingMouse;
    private Vector2 _onClickMousePosition;

    public void Construct(Ball ball, DefaultControls controls)
    {
        InitBall(ball);
        InitControls(controls);
    }

    public Ball Ball => _ball;

    private void Update()
    {
        if (_isHoldingMouse)
        {
            Vector3 rotationPoint = _ball.transform.position;
            float mouseX = _controls.DefaultActionMap.MouseX.ReadValue<float>();
            float rotationAngle = RotationSpeed * mouseX;
            transform.RotateAround(rotationPoint, Vector3.up, rotationAngle * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        if (_controls != null)
        {
            _controls.DefaultActionMap.LeftMouseButtonPress.started -= OnLeftMouseButtonPressStarted;
            _controls.DefaultActionMap.LeftMouseButtonPress.canceled -= OnLeftMouseButtonPressCanceled;
        }
    }

    private void InitBall(Ball ball)
    {
        _ball = ball;
        _ballOffset = transform.position - _ball.transform.position;
    }

    private void InitControls(DefaultControls controls)
    {
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += OnLeftMouseButtonPressStarted;
        _controls.DefaultActionMap.LeftMouseButtonPress.canceled += OnLeftMouseButtonPressCanceled;
    }

    private void OnLeftMouseButtonPressStarted(InputAction.CallbackContext obj)
    {
        _isHoldingMouse = true;
        _ball.ResetMove();
        transform.position = _ball.transform.position + _ballOffset;
        _onClickMousePosition = Mouse.current.position.ReadValue();
    }

    private void OnLeftMouseButtonPressCanceled(InputAction.CallbackContext obj)
    {
        _isHoldingMouse = false;
        Vector2 onReleaseMousePosition = Mouse.current.position.ReadValue();
        float mouseDelta = Vector2.Distance(onReleaseMousePosition, _onClickMousePosition);
        Vector3 forceDirection = (_ball.transform.position - transform.position).normalized;
        forceDirection.y = 0;
        _ball.AddForce(forceDirection * mouseDelta);
    }
}
