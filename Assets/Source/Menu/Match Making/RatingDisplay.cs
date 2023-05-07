using TMPro;
using UnityEngine;

public class RatingDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerRatingText;
    [SerializeField] private GameObject _botRatingObj;
    [SerializeField] private TMP_Text _botRatingText;

    public void DisplayPlayerRating(int rating)
    {
        _playerRatingText.text = rating.ToString();
    }

    public void DisplayBotRating(int rating)
    {
        _botRatingObj.SetActive(true);
        _botRatingText.text = rating.ToString();
    }
}
