using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private Player _player;

    public void Construct(Player player)
    {
        _player = player;
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        if (_player != null)
        {
            _player.ScoreChanged -= OnScoreChanged;
        }
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
