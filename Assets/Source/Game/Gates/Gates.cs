using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gates : MonoBehaviour
{
    public event Action<Gates> GoalScored;

    private const int PointsToAdd = 1;

    [SerializeField] private MoveAnimation _moveAnimation;
    [SerializeField] private ScaleAnimation _scaleAnimation;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.Owner.AddPoints(PointsToAdd);
            StartCoroutine(PlayGoalAnimation());
        }
    }

    private IEnumerator PlayGoalAnimation()
    {
        PlayAnimations();
        yield return new WaitForSeconds(_moveAnimation.Duration);
        StopAnimations();
        GoalScored?.Invoke(this);
    }

    private void StopAnimations()
    {
        _moveAnimation.Stop();
        _scaleAnimation.Stop();
        _collider.enabled = true;
    }

    private void PlayAnimations()
    {
        _collider.enabled = false;
        _moveAnimation.PlayOnce();
        _scaleAnimation.PlayOnce();
    }
}
