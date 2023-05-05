using TMPro;
using UnityEngine;

public class GoalSign : MonoBehaviour
{
    [SerializeField] private TMP_Text _goalText;
    [SerializeField] private ScaleAnimation _scaleAnimation;

    private Gates[] _gates;

    public void Construct(params Gates[] gates)
    {
        _gates = gates;

        for (int i = 0; i < gates.Length; i++)
        {
            _gates[i].GoalStarted += OnGoalStarted;
        }
    }

    private void OnDestroy()
    {
        if (_gates == null)
        {
            return;
        }

        for (int i = 0; i < _gates.Length; i++)
        {
            _gates[i].GoalStarted -= OnGoalStarted;
        }
    }

    private void OnGoalStarted(Gates gates)
    {
        _scaleAnimation.PlayOnce();
    }
}
