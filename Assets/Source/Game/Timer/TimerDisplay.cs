using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private ReverseTimer _timer;

    private void Update()
    {
        int minutes = Mathf.Max(0, Mathf.FloorToInt(_timer.Value / 60));
        int seconds = Mathf.Max(0, Mathf.CeilToInt(_timer.Value % 60));

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
