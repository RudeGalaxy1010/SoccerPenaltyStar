using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    private const int Once = 1;
    private const int Rewind = 2;
    private const int Infinite = -1;

    [SerializeField] private float _scaleEndValue;
    [SerializeField] private float _duration;
    [SerializeField] private bool _isRelativeScale;

    private Tween _tween;

    public float Duration => _duration;
    private float HalfDuration => _duration / 2f;

    public void PlayOnce()
    {
        Stop();
        Play(Duration, Once);
    }

    public void PlayOnceWithRewind()
    {
        Stop();
        Play(HalfDuration, Rewind);
    }

    public void PlayInfinite()
    {
        Stop();
        Play(HalfDuration, Infinite);
    }

    public void Stop()
    {
        if (_tween != null)
        {
            _tween.Rewind();
            _tween.Kill();
        }
    }

    private void Play(float duration, int loops)
    {
        float relativeScaleEndValue = _isRelativeScale ? _scaleEndValue * transform.localScale.x : _scaleEndValue;
        _tween = transform.DOScale(relativeScaleEndValue, duration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
