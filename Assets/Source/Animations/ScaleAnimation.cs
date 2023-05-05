using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _scaleEndValue;
    [SerializeField] private float _duration;
    [SerializeField] private bool _isRelativeScale;

    private Tween _tween;

    public void PlayOnce()
    {
        Stop();
        Play(2);
    }

    public void PlayInfinite()
    {
        Stop();
        Play(-1);
    }

    public void Stop()
    {
        if (_tween != null)
        {
            _tween.Rewind();
            _tween.Kill();
        }
    }

    private void Play(int loops)
    {
        float relativeScaleEndValue = _isRelativeScale ? _scaleEndValue * transform.localScale.x : _scaleEndValue;
        float halfDuration = _duration / 2f; // Scale up and return to default takes double time
        _tween = transform.DOScale(relativeScaleEndValue, halfDuration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
