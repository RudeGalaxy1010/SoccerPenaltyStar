using System;
using UnityEngine;

public class ReverseTimer : MonoBehaviour
{
    public event Action Expired;

    private float _duration;
    private float _timer;
    private bool _isActive;

    public void Construct(float duration)
    {
        _duration = duration;
        _timer = _duration;
        _isActive = true;
    }

    public float Value => _timer;

    private void Update()
    {
        if (_isActive == false)
        {
            return;
        }

        if (_timer <= 0)
        {
            _isActive = false;
            Expired?.Invoke();
        }

        _timer -= Time.deltaTime;
    }
}
