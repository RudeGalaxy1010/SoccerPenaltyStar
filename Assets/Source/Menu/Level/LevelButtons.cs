using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private Button _readyButton;

    [Header("Match Maker")]
    [SerializeField] private MatchMaker _matchMaker;

    private SkinPartsUnlocker _skinPartsUnlocker;

    public void Construct(SkinPartsUnlocker skinPartsUnlocker)
    {
        _skinPartsUnlocker = skinPartsUnlocker;
        _skinPartsUnlocker.PurchaseNeeded += OnPurchaseNeeded;
        _skinPartsUnlocker.PurchaseCompleted += OnPurchaseCompleted;
        _skinPartsUnlocker.PurchaseCancelled += OnPurchaseCancelled;
    }

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

    private void OnDestroy()
    {
        if (_skinPartsUnlocker != null)
        {
            _skinPartsUnlocker.PurchaseNeeded -= OnPurchaseNeeded;
            _skinPartsUnlocker.PurchaseCompleted -= OnPurchaseCompleted;
            _skinPartsUnlocker.PurchaseCancelled -= OnPurchaseCancelled;
        }
    }

    private void OnMatchMakingStarted()
    {
        _readyButton.interactable = false;
    }

    private void OnStartButtonClicked()
    {
        _matchMaker.StartSelectingBot();
    }

    private void OnPurchaseNeeded()
    {
        _readyButton.interactable = false;
    }

    private void OnPurchaseCompleted()
    {
        _readyButton.interactable = true;
    }

    private void OnPurchaseCancelled()
    {
        _readyButton.interactable = true;
    }
}
