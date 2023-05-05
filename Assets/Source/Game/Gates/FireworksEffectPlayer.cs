using UnityEngine;

public class FireworksEffectPlayer : MonoBehaviour
{
    [SerializeField] private Gates _gates;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _gates.GoalStarted += OnGoalStarted;
        _gates.GoalScored += OnGoalScored;
    }

    private void OnDisable()
    {
        _gates.GoalStarted -= OnGoalStarted;
        _gates.GoalScored -= OnGoalScored;
    }

    private void OnGoalStarted(Gates gates)
    {
        _effect.Play();
    }

    private void OnGoalScored(Gates obj)
    {
        _effect.Stop();
    }
}
