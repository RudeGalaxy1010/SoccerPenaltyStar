using System;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private PurchaseCostDisplay _purchaseCostDisplay;

    private SkinPartsUnlocker _skinPartsUnlocker;

    public void Construct(SkinPartsUnlocker skinPartsUnlocker)
    {
        _skinPartsUnlocker = skinPartsUnlocker;
        _skinPartsUnlocker.PurchaseNeeded += OnPurchaseNeeded;
        _skinPartsUnlocker.PurchaseCompleted += OnPurchaseCompleted;
        _skinPartsUnlocker.PurchaseCancelled += OnPurchaseCancelled;
        _purchaseButton.gameObject.SetActive(false);
        _purchaseCostDisplay.Hide();
    }

    private void OnEnable()
    {
        _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
    }

    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnPurchaseButtonClicked);
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

    private void OnPurchaseButtonClicked()
    {
        _skinPartsUnlocker.Purchase();
        Hide();
    }

    private void OnPurchaseNeeded()
    {
            _purchaseButton.gameObject.SetActive(true);
        _purchaseButton.interactable = _skinPartsUnlocker.CanPurchase;
        _purchaseCostDisplay.Display(_skinPartsUnlocker.TotalCost);
    }

    private void OnPurchaseCompleted()
    {
        Hide();
    }

    private void OnPurchaseCancelled()
    {
        Hide();
    }

    private void Hide()
    {
        _purchaseButton.gameObject.SetActive(false);
        _purchaseCostDisplay.Hide();
    }
}
