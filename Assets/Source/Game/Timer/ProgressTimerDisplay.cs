using UnityEngine;
using UnityEngine.UI;

public class ProgressTimerDisplay : MonoBehaviour
{
    [SerializeField] private Image _progressImage;
    [SerializeField] private ReverseTimer _timer;

    private void Update()
    {
        _progressImage.fillAmount = _timer.Progress;
    }
}
