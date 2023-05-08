using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    private const string CoinsText = "Total coins";
    private const string RatingText = "Total rating";

    [SerializeField] private GameObject _winImage;
    [SerializeField] private GameObject _loseImage;
    [SerializeField] private GameObject _drawImage;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _ratingText;
    [SerializeField] private Button _backButton;

    private LevelLoader _levelLoader;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonCLicked);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonCLicked);
    }

    private void Start()
    {
        _levelLoader = new LevelLoader();
    }

    public void DisplayWin(float coins, int rating)
    {
        DisableAllImages();
        _winImage.SetActive(true);
        DisplayReward(coins, rating);
    }

    public void DisplayLose(float coins, int rating)
    {
        DisableAllImages();
        _loseImage.SetActive(true);
        DisplayReward(coins, rating);
    }

    public void DisplayDraw(float coins, int rating)
    {
        DisableAllImages();
        _drawImage.SetActive(true);
        DisplayReward(coins, rating);
    }

    private void DisplayReward(float coins, int rating)
    {
        gameObject.SetActive(true);
        _coinsText.text = $"{CoinsText} {coins}";
        _ratingText.text = $"{RatingText} {rating}";
    }

    private void DisableAllImages()
    {
        _winImage.SetActive(false);
        _loseImage.SetActive(false);
        _drawImage.SetActive(false);
    }

    private void OnBackButtonCLicked()
    {
        _levelLoader.LoadMenu();
    }
}
