using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallLauncher : BallLauncher
{
    private Controls _controls;
    private ActualPlayer _player;

    private Vector3 _startMousePosition;

    private float _cameraPositionZ;
    private Camera _camera;

    public PlayerBallLauncher(ActualPlayer player, Ball ball, Controls controls) : base(player, ball)
    {
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += (ctx) => OnLeftMouseButtonPressStarted();
        _controls.DefaultActionMap.LeftMouseButtonPress.canceled += (ctx) => OnLeftMouseButtonPressCanceled();
        _player = player;
    }

    public bool IsHolding => _startMousePosition != Vector3.zero;
    public Vector3 Force => GetForce(GetDelta());

    private void OnLeftMouseButtonPressStarted()
    {
        PrepareLaunch();
    }

    private void OnLeftMouseButtonPressCanceled()
    {
        Launch();
    }

    public override void PrepareLaunch()
    {
        Ball.ResetMove();
        _player.TeleportToBall();
        _player.EnableRotation();
        _startMousePosition = GetMousePositionInWorld();
    }

    public override void Launch()
    {
        _player.DisableRotation();
        float delta = GetDelta();
        Vector3 force = GetForce(delta);
        Ball.AddForce(force);
        ResetMousePositions();
    }

    private void ResetMousePositions()
    {
        _startMousePosition = Vector3.zero;
    }

    protected override float GetDelta()
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
