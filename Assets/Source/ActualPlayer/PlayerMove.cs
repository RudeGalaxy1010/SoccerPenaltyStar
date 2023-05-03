using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _point;
    private Vector3 _offset;

    public void Construct(Transform playerTransform, Transform ballTransform, Vector3 offset)
    {
        _playerTransform = playerTransform;
        _point = ballTransform;
        _offset = offset;
    }

    public void TeleportToBall()
    {
        _playerTransform.position = _point.position + _offset;
    }
}
