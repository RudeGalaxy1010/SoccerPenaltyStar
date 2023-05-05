using UnityEngine;

public class FireworksEffectPlayer : MonoBehaviour
{
    [SerializeField] private Gates _gates;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _gates.GoalStarted += OnGoalStarted;
    }

    private void OnDisable()
    {
        _gates.GoalStarted -= OnGoalStarted;
    }

    private void OnGoalStarted(Gates gates)
    {
        _effect.Play();
    }
}
