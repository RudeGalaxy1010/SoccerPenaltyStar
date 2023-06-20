using UnityEngine;

public class PlayerBallLauncher : BallLauncher, IPauseable
{
    private Controls _controls;
    private ActualPlayer _player;
    private PlayerRotation _playerRotation;

    private Vector3 _startMousePosition;

    private float _cameraPositionZ;
    private Camera _camera;
    private bool _isPause;
    private float _delta;

    public Joystick joystick;

    public PlayerBallLauncher(ActualPlayer player, PlayerRotation playerRotation, Ball ball, Controls controls) 
        : base(player, ball)
    {
        _controls = controls;
        _controls.DefaultMap.FireButtonPressed.started += (ctx) => OnLeftMouseButtonPressStarted();
        _controls.DefaultMap.FireButtonPressed.canceled += (ctx) => OnLeftMouseButtonPressCanceled();
        _player = player;
        _playerRotation = playerRotation;
    }

    public bool IsHolding => _startMousePosition != Vector3.zero;
    public Vector3 Force => GetForce(GetDelta());
    private float SkinForceMultiplier => 1 + DataHolder.PlayerForce / 5f;

    private void OnLeftMouseButtonPressStarted()
    {
        if (_isPause == true)
        {
            return;
        }

        PrepareLaunch();
    }

    private void OnLeftMouseButtonPressCanceled()
    {
        if (_isPause == true)
        {
            return;
        }

        Launch();
    }

    public override void PrepareLaunch()
    {
        _delta = 0;
        Ball.ResetMove();
        _player.TeleportToBall();
        _player.EnableRotation();
        _startMousePosition = GetMousePositionInWorld();
    }

    public override void Launch()
    {
        _player.DisableRotation();
        float delta = GetDelta();
        Vector3 force = GetForce(delta) * SkinForceMultiplier;
        Ball.AddForce(force);
        ResetMousePositions();
        BallLaunched?.Invoke();
    }

    private void ResetMousePositions()
    {
        _startMousePosition = Vector3.zero;
    }

    protected override float GetDelta()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        Vector3 m = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        float directionSign = Mathf.Sign(0 - m.z);
        float newDelta = directionSign * (Vector3.zero - m).magnitude;

        if (newDelta * _delta < 0)
        {
            _playerRotation.SwitchRotationSide();
        }

        _delta = newDelta;

        return _delta;
    }

    private Vector3 GetMousePositionInWorld()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
            _cameraPositionZ = _camera.transform.position.z;
        }

        Vector2 rawScreenPosition = _controls.DefaultMap.Position.ReadValue<Vector2>();
        Vector3 screenPosition = new Vector3(rawScreenPosition.x, rawScreenPosition.y, -_cameraPositionZ);
        return _camera.ScreenToWorldPoint(screenPosition);
    }

    public void Pause()
    {
        _isPause = true;
        ResetMousePositions();
    }

    public void Resume()
    {
        _isPause = false;
    }
}
