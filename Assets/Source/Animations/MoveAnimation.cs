using DG.Tweening;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _shift;
    [SerializeField] private float _duration;

    private Tween _tween;

    public float Duration => _duration;

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
        Vector3 endValue = transform.position + _shift;
        float halfDuration = _duration / 2f; // Scale up and return to default takes double time
        _tween = transform.DOMove(endValue, halfDuration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
