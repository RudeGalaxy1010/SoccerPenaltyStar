using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Ball _ball;
    private Vector3 _ballOffset;
    private DefaultControls _controls;
    private Vector2 _onClickMousePosition;

    public void Construct(Ball ball, DefaultControls controls)
    {
        InitBall(ball);
        InitControls(controls);
    }

    public Ball Ball => _ball;

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
        transform.position = _ball.transform.position + _ballOffset;
        _onClickMousePosition = Mouse.current.position.ReadValue();
    }

    private void OnLeftMouseButtonPressCanceled(InputAction.CallbackContext obj)
    {
        Vector2 onReleaseMousePosition = Mouse.current.position.ReadValue();
        float mouseDelta = Vector2.Distance(onReleaseMousePosition, _onClickMousePosition);
        Vector3 forceDirection = (_ball.transform.position - transform.position).normalized;
        _ball.AddForce(forceDirection * mouseDelta);
    }
}
