using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Player _player;
    private Transform _point;
    private Controls _controls;
    private Vector3 _offset;

    public void Construct(Player player, Transform point, Controls controls, Vector3 offset)
    {
        _player = player;
        _point = point;
        _offset = offset;
        _controls = controls;
        _controls.DefaultActionMap.LeftMouseButtonPress.started += (ctx) => OnLeftMouseButtonPressStarted();
    }

    private void OnLeftMouseButtonPressStarted()
    {
        _player.transform.position = _point.position + _offset;
    }
}
