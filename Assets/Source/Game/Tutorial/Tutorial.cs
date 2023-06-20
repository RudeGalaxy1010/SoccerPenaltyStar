using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite _ru;
    [SerializeField] private Sprite _en;
    [SerializeField] private Sprite _tr;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private Image _tutorialImage;
    [SerializeField] private Button _closeButton;

    private Pause _pause;
    private Init _initSDK;

    public void Construct(Pause pause)
    {
        if (DataHolder.PlayerData.IsFirstLaunch == false)
        {
            return;
        }

        _initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
        _pause = pause;
        _pause.SetPause(true);
        ShowTutorial();
        DataHolder.PlayerData.IsFirstLaunch = false;
        _initSDK.Save();
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void ShowTutorial()
    {
        if (_initSDK.language == LanguageConstants.RU)
        {
            _tutorialImage.sprite = _ru;
        }
        else if (_initSDK.language == LanguageConstants.TR)
        {
            _tutorialImage.sprite = _tr;
        }
        else
        {
            _tutorialImage.sprite = _en;
        }

        _tutorialPanel.SetActive(true);
    }

    private void OnCloseButtonClicked()
    {
        _tutorialPanel.SetActive(false);
        _pause.SetPause(false);
    }
}
