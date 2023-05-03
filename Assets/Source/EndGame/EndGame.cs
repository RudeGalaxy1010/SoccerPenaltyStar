using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    private Score _playerScore;
    private Score _botScore;
    private Pause _pause;

    public void Construct(Score playerScore, Score botScore, Pause pause)
    {
        _playerScore = playerScore;
        _botScore = botScore;
        _pause = pause;
    }

    private void OnEnable()
    {
        _timer.Expired += OnTimerExpired;
    }

    private void OnDisable()
    {
        _timer.Expired -= OnTimerExpired;
    }

    private void OnTimerExpired()
    {
        _pause.SetPause(true);

        if (_playerScore.Points > _botScore.Points)
        {
            Debug.Log("Win!");
        }
        else if (_playerScore.Points < _botScore.Points)
        {
            Debug.Log("Lose!");
        }
        else
        {
            Debug.Log("Draw!");
        }
    }
}
