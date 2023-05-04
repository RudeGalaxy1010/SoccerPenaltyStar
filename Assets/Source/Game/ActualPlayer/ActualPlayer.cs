using UnityEngine;

public class ActualPlayer : Player, IPauseable
{
    [SerializeField] private SkinApplier _skinApplier;

    private PlayerMove _move;
    private PlayerRotation _rotation;
    private bool _isPause;

    public void Construct(SkinCustomization skinPrefab, Score score, Controls controls, 
        Transform ballTransform, Vector3 offsetFromBall)
    {
        Construct(score);
        _move = GetComponent<PlayerMove>();
        _move.Construct(transform, ballTransform, offsetFromBall);
        _rotation = GetComponent<PlayerRotation>();
        _rotation.Construct(controls, transform, ballTransform);
        _skinApplier.Construct(skinPrefab);
    }

    public void TeleportToBall()
    {
        if (_isPause)
        {
            return;
        }

        _move.TeleportToBall();
    }

    public void EnableRotation()
    {
        if (_isPause)
        {
            return;
        }

        _rotation.Enable();
    }

    public void DisableRotation()
    {
        _rotation.Disable();
    }

    public void Pause()
    {
        _isPause = true;
        DisableRotation();
    }

    public void Resume() 
    { 
        _isPause = false;
    }
}
