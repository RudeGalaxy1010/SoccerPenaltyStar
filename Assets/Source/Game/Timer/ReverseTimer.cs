using System;
using UnityEngine;

public class ReverseTimer : MonoBehaviour, IPauseable
{
    public event Action Expired;

    private float _duration;
    private float _timer;
    private bool _isInited;
    private bool _isPaused;

    public void Construct(float duration)
    {
        _duration = duration;
        _timer = _duration;
        _isInited = true;
    }

    public float Value => _timer;

    private void Update()
    {
        if (_isInited == false || _isPaused == true)
        {
            return;
        }

        if (_timer <= 0)
        {
            _isInited = false;
            Expired?.Invoke();
        }

        _timer -= Time.deltaTime;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = false;
    }
}
