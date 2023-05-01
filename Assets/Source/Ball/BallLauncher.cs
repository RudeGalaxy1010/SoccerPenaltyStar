using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher
{
    private const float MinForce = 1f;
    private const float MaxForce = 100f;

    private Controls _controls;
    private Player _player;
    private Ball _ball;

    private Vector2 _startMousePosition;
    private Vector2 _endMousePosition;

    public BallLauncher(Controls controls, Player player, Ball ball)
    {
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += OnLeftMouseButtonPressStarted;
        _controls.DefaultActionMap.LeftMouseButtonPress.canceled += OnLeftMouseButtonPressCanceled;
        _player = player;
        _ball = ball;
    }

    public void Destruct()
    {
        if (_controls != null)
        {
            _controls.DefaultActionMap.LeftMouseButtonPress.started -= OnLeftMouseButtonPressStarted;
            _controls.DefaultActionMap.LeftMouseButtonPress.canceled -= OnLeftMouseButtonPressCanceled;
        }
    }

    private void OnLeftMouseButtonPressStarted(InputAction.CallbackContext obj)
    {
        _ball.ResetMove();
        _startMousePosition = Mouse.current.position.ReadValue();
    }

    private void OnLeftMouseButtonPressCanceled(InputAction.CallbackContext obj)
    {
        _endMousePosition = Mouse.current.position.ReadValue();
        // TODO: normalize delta
        float delta = Vector2.Distance(_startMousePosition, _endMousePosition);
        Vector3 force = GetForce(delta);
        _ball.AddForce(force);
    }

    private Vector3 GetForce(float delta)
    {
        Vector3 forceDirection = GetNormalizedForceDirection();
        Vector3 rawForce = forceDirection;
        float clampedDelta = Mathf.Clamp(MinForce, delta, MaxForce);
        return rawForce * clampedDelta;
    }

    private Vector3 GetNormalizedForceDirection()
    {
        Vector3 ballFlatPosition = new Vector3(_ball.transform.position.x, 0, _ball.transform.position.z);
        Vector3 playerFlatPosition = new Vector3(_player.transform.position.x, 0, _player.transform.position.z);
        Vector3 forceDirection = playerFlatPosition - ballFlatPosition;
        return forceDirection.normalized;
    }
}
