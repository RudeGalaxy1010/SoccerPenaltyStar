using System;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const float Speed = 180f;

    private Player _player;
    private Transform _point;
    private Controls _controls;
    private bool _isHolding;

    public void Construct(Player player, Transform point, Controls controls)
    {
        _player = player;
        _point = point;
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += (ctx) => OnLeftMouseButtonPressStarted();
        _controls.DefaultActionMap.LeftMouseButtonPress.canceled += (ctx) => OnLeftMouseButtonPressCanceled();
    }

    private void OnLeftMouseButtonPressStarted()
    {
        _isHolding = true;
    }

    private void OnLeftMouseButtonPressCanceled()
    {
        _isHolding = false;
    }

    private void Update()
    {
        if (_isHolding == false)
        {
            return;
        }

        float delta = -_controls.DefaultActionMap.MouseX.ReadValue<float>();
        _player.transform.RotateAround(_point.position, Vector3.up, Speed * delta * Time.deltaTime);
    }
}
