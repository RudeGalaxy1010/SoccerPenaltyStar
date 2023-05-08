using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    private Score _playerScore;
    private Score _botScore;
    private Coins _money;
    private Pause _pause;
    private RatingCalculator _ratingCalculator;

    public void Construct(Score playerScore, Score botScore, Coins money, Pause pause)
    {
        _playerScore = playerScore;
        _botScore = botScore;
        _money = money;
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
            _money.AddWinMoney();
            Debug.Log("Win!");
        }
        else if (_playerScore.Points < _botScore.Points)
        {
            ratingChange = _ratingCalculator.GetRandomDefeatRating();
            _money.SubDefeatMoney();
            Debug.Log("Lose!");
        }
        else
        {
            ratingChange = _ratingCalculator.GetDrawRating();
            _money.AddDrawMoney();
            Debug.Log("Draw!");
        }

        DataHolder.PlayerData.PlayerRating += ratingChange;
    }
}
