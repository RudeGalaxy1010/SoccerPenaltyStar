using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    private const string CoinsText = "Всего монет";
    private const string RatingText = "Всего рейтинга";

    private const string CoinsTextRus = "Total coins";
    private const string RatingTextRus = "Total rating";

    private const string CoinsTextTur = "Toplam madeni para";
    private const string RatingTextTur = "Toplam puan";

    [SerializeField] private GameObject _winImage;
    [SerializeField] private GameObject _loseImage;
    [SerializeField] private GameObject _drawImage;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _ratingText;
    [SerializeField] private Button _backButton;

    [SerializeField] private Sprite winRus;
    [SerializeField] private Sprite winTur;
    [SerializeField] private Sprite loseRus;
    [SerializeField] private Sprite loseTur;
    [SerializeField] private Sprite drawRus;
    [SerializeField] private Sprite drawTur;

    [SerializeField] private GoalLocal goalLocal;

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
        if (goalLocal.initSDK.language == "ru")
        {
            _winImage.GetComponent<Image>().sprite = winRus;
        }
        else if (goalLocal.initSDK.language == "tr")
        {
            _winImage.GetComponent<Image>().sprite = winTur;
        }
        _winImage.GetComponent<Image>().SetNativeSize();
        DisplayReward(coins, rating);
    }

    public void DisplayLose(float coins, int rating)
    {
        DisableAllImages();
        _loseImage.SetActive(true);
        if (goalLocal.initSDK.language == "ru")
        {
            _loseImage.GetComponent<Image>().sprite = loseRus;
        }
        else if (goalLocal.initSDK.language == "tr")
        {
            _loseImage.GetComponent<Image>().sprite = loseTur;
        }
        _loseImage.GetComponent<Image>().SetNativeSize();
        DisplayReward(coins, rating);
    }

    public void DisplayDraw(float coins, int rating)
    {
        DisableAllImages();
        _drawImage.SetActive(true);
        if (goalLocal.initSDK.language == "ru")
        {
            _drawImage.GetComponent<Image>().sprite = drawRus;
        }
        else if (goalLocal.initSDK.language == "tr")
        {
            _drawImage.GetComponent<Image>().sprite = drawTur;
        }
        _drawImage.GetComponent<Image>().SetNativeSize();
        DisplayReward(coins, rating);
    }

    private void DisplayReward(float coins, int rating)
    {
        gameObject.SetActive(true);
        if (goalLocal.initSDK.language == "en")
        {
            _coinsText.text = $"{CoinsText}      {coins}";
            _ratingText.text = $"{RatingText}      {rating}";
        }
        else if (goalLocal.initSDK.language == "ru")
        {
            _coinsText.text = $"{CoinsTextRus}      {coins}";
            _ratingText.text = $"{RatingTextRus}      {rating}";
        }
        else if (goalLocal.initSDK.language == "tr")
        {
            _coinsText.text = $"{CoinsTextTur}      {coins}";
            _ratingText.text = $"{RatingTextTur}      {rating}";
        }
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
