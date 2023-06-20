using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Init initSDK;
    public static int gameNumber;

    [SerializeField] private ReverseTimer _timer;
    [SerializeField] private EndGamePanel _endGamePanel;

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
        initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
    }

    private void OnDisable()
    {
        _timer.Expired -= OnTimerExpired;
        initSDK = null;
    }

    private void OnTimerExpired()
    {
        _pause.SetPause(true);
        int ratingChange = 0;

        if (_playerScore.Points > _botScore.Points)
        {
            ratingChange = _ratingCalculator.GetRandomWinRating();
            _money.AddWinMoney();
            _endGamePanel.DisplayWin(Coins.WinMoney, ratingChange);
        }
        else if (_playerScore.Points < _botScore.Points)
        {
            ratingChange = _ratingCalculator.GetRandomDefeatRating();
            _money.SubDefeatMoney();
            _endGamePanel.DisplayLose(-Coins.DefeatMoney, ratingChange);
        }
        else
        {
            ratingChange = _ratingCalculator.GetDrawRating();
            _money.AddDrawMoney();
            _endGamePanel.DisplayDraw(Coins.DrawMoney, ratingChange);
        }

        DataHolder.PlayerData.PlayerRating += ratingChange;
        gameNumber += 1;
        if (gameNumber == 2)
        {
            initSDK.RateGameFunc();
        }
        else
        {
            initSDK.ShowInterstitialAd();
        }
    }
}
