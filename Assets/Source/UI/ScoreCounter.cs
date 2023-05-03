using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private Score _score;

    public void Construct(Score score)
    {
        _score = score;
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        if (_score != null)
        {
            _score.ScoreChanged -= OnScoreChanged;
        }
    }

    private void OnScoreChanged(int value)
    {
        _scoreText.text = value.ToString();
    }
}
