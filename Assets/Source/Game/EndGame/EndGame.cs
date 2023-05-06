using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    private Score _playerScore;
    private Score _botScore;
    private Pause _pause;
    private RatingCalculator _ratingCalculator;

    public void Construct(Score playerScore, Score botScore, Pause pause)
    {
        _playerScore = playerScore;
        _botScore = botScore;
        _pause = pause;
        _ratingCalculator = new RatingCalculator();
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
        int ratingChange = 0;

        if (_playerScore.Points > _botScore.Points)
        {
            ratingChange = _ratingCalculator.GetRandomWinRating();
            Debug.Log("Win!");
        }
        else if (_playerScore.Points < _botScore.Points)
        {
            ratingChange = _ratingCalculator.GetRandomDefeatRating();
            Debug.Log("Lose!");
        }
        else
        {
            ratingChange = _ratingCalculator.GetDrawRating();
            Debug.Log("Draw!");
        }

        DataHolder.PlayerData.PlayerRating += ratingChange;
        Debug.Log(DataHolder.PlayerData.PlayerRating);
    }
}
