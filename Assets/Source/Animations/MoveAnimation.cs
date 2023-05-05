using DG.Tweening;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private const int Once = 1;
    private const int Rewind = 2;
    private const int Infinite = -1;

    [SerializeField] private Vector3 _shift;
    [SerializeField] private float _duration;

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
        Vector3 endValue = transform.position + _shift;
        _tween = transform.DOMove(endValue, duration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
