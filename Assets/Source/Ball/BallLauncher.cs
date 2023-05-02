using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher
{
    private const float MinForce = 1f;
    private const float MaxForce = 10f;
    private const float ForceScale = 4f;

    private Controls _controls;
    private Player _player;
    private Ball _ball;

    private Vector3 _startMousePosition;

    private float _cameraPositionZ;
    private Camera _camera;

    public BallLauncher(Controls controls, Player player, Ball ball)
    {
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += (ctx) => OnLeftMouseButtonPressStarted();
        _controls.DefaultActionMap.LeftMouseButtonPress.canceled += (ctx) => OnLeftMouseButtonPressCanceled();
        _player = player;
        _ball = ball;
    }

    public bool IsHolding => _startMousePosition != Vector3.zero;
    public Vector3 Force => GetForce(GetDelta());

    private void OnLeftMouseButtonPressStarted()
    {
        _ball.ResetMove();
        _startMousePosition = GetMousePositionInWorld();
    }

    private void OnLeftMouseButtonPressCanceled()
    {
        Vector3 force = GetForce(GetDelta());
        ResetMousePositions();
        _ball.AddForce(force * ForceScale);
    }

    private void ResetMousePositions()
    {
        _startMousePosition = Vector3.zero;
    }

    private Vector3 GetForce(float delta)
    {
        Vector3 forceDirection = GetNormalizedForceDirection();
        Vector3 rawForce = forceDirection;
        float clampedDelta = Mathf.Clamp(delta, MinForce, MaxForce);
        return rawForce * clampedDelta;
    }

    private Vector3 GetNormalizedForceDirection()
    {
        Vector2 ballFlatPosition = new Vector3(_ball.transform.position.x, _ball.transform.position.z);
        Vector2 playerFlatPosition = new Vector3(_player.transform.position.x, _player.transform.position.z);
        Vector2 forceDirection = ballFlatPosition - playerFlatPosition;
        return new Vector3(forceDirection.x, 0, forceDirection.y).normalized;
    }

    private float GetDelta()
    {
        Vector3 endMousePosition = GetMousePositionInWorld();
        Vector3 delta = endMousePosition - _startMousePosition;        
        return delta.magnitude;
    }

    private Vector3 GetMousePositionInWorld()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
            _cameraPositionZ = _camera.transform.position.z;
        }

        Vector2 rawScreenPosition = Mouse.current.position.ReadValue();
        Vector3 screenPosition = new Vector3(rawScreenPosition.x, rawScreenPosition.y, -_cameraPositionZ);
        return _camera.ScreenToWorldPoint(screenPosition);
    }
}
