using UnityEngine;

[DisallowMultipleComponent]
public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private float _speed = 12.5f;
    [SerializeField] private Vector3 _offset;

    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        SmoothMove();
    }

    private void SmoothMove()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 desiredPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _speed * Time.deltaTime);
    }
}
