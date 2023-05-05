using UnityEngine;

public class WinnerDisplayer : MonoBehaviour
{
    private Score _playerScore;
    private Score _botScore;
    private GameObject _playerStar;
    private GameObject _botStar;

    public void Construct(Score playerScore, Score botScore, GameObject playerStar, GameObject botStar)
    {
        _playerScore = playerScore;
        _botScore = botScore;
        _playerStar = playerStar;
        _botStar = botStar;
    }

    private void Update()
    {
        if (_playerScore == null || _botScore == null)
        {
            return;
        }

        if (_playerScore.Points > _botScore.Points)
        {
            _botStar.SetActive(false);
            _playerStar.SetActive(true);
        }
        else if (_playerScore.Points < _botScore.Points)
        {
            _botStar.SetActive(true);
            _playerStar.SetActive(false);
        }
        else
        {
            _botStar.SetActive(false);
            _playerStar.SetActive(false);
        }
    }
}
