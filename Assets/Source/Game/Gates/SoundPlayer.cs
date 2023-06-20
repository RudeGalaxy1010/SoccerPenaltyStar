using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _goalClip;
    [SerializeField] private AudioClip _kickClip;

    private Gates[] _gates;
    private BallLauncher[] _ballLaunchers;

    public void Construct(Gates[] gates, BallLauncher[] ballLaunchers)
    {
        _gates = gates;
        _ballLaunchers = ballLaunchers;

        for (int i = 0; i < _gates.Length; i++)
        {
            _gates[i].GoalStarted += OnGoalStarted;
        }

        for (int i = 0; i < _ballLaunchers.Length; i++)
        {
            _ballLaunchers[i].BallLaunched += OnBallLaunched;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _gates.Length; i++)
        {
            _gates[i].GoalStarted -= OnGoalStarted;
        }

        for (int i = 0; i < _ballLaunchers.Length; i++)
        {
            _ballLaunchers[i].BallLaunched -= OnBallLaunched;
        }
    }

    private void OnGoalStarted(Gates gates)
    {
        _audioSource.PlayOneShot(_goalClip);
    }

    private void OnBallLaunched()
    {
        _audioSource.PlayOneShot(_kickClip);
    }
}
