using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    private Score _playerScore;
    private Score _botScore;

    public void Construct(Score playerScore, Score botScore)
    {
        _playerScore = playerScore;
        _botScore = botScore;
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
