using TMPro;
using UnityEngine;

public class RatingDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerRatingText;
    [SerializeField] private TMP_Text _botRatingText;

    public void DisplayPlayerRating(int rating)
    {
        _playerRatingText.text = rating.ToString();
    }

    public void DisplayBotRating(int rating)
    {
        _botRatingText.text = rating.ToString();
    }
}
