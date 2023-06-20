using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gates : MonoBehaviour
{
    public event Action<Gates> GoalStarted;
    public event Action<Gates> GoalScored;

    [SerializeField] private int PointsToAdd = 1;
    [SerializeField] private MoveAnimation _moveAnimation;
    [SerializeField] private ScaleAnimation _scaleAnimation;
    [SerializeField] private GoalSign _goalSign;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            _collider.enabled = false;
            ball.Owner.AddPoints(PointsToAdd);
            GoalStarted?.Invoke(this);
            StartCoroutine(PlayGoalAnimation());
        }
    }

    public void Reset()
    {
        _collider.enabled = true;
    }

    private IEnumerator PlayGoalAnimation()
    {
        PlayAnimations();
        float waitTime = Mathf.Max(_moveAnimation.Duration, _scaleAnimation.Duration);
        yield return new WaitForSeconds(waitTime);
        StopAnimations();
        GoalScored?.Invoke(this);
    }

    private void StopAnimations()
    {
        _moveAnimation.Stop();
        _scaleAnimation.Stop();
    }

    private void PlayAnimations()
    {
        _moveAnimation.PlayOnceWithRewind();
        _scaleAnimation.PlayOnceWithRewind();
    }
}
