using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private Button _readyButton;

    [Header("Match Maker")]
    [SerializeField] private MatchMaker _matchMaker;

    private void Start()
    {
        _readyButton.interactable = true;
    }

    private void OnEnable()
    {
        _readyButton.onClick.AddListener(OnStartButtonClicked);
        _matchMaker.MatchMakingStarted += OnMatchMakingStarted;
    }

    private void OnDisable()
    {
        _readyButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void OnMatchMakingStarted()
    {
        _readyButton.interactable = false;
    }

    private void OnStartButtonClicked()
    {
        _matchMaker.StartSelectingBot();
    }
}
