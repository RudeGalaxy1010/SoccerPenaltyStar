using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    public event Action<ShopItem> Clicked;

    [SerializeField] private Button _purchaseButton;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _cost;

    private ShopItem _item;

    private void OnEnable()
    {
        _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
    }

    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnPurchaseButtonClicked);
    }

    public void SetItem(ShopItem shopItem)
    {
        _item = shopItem;
        _name.text = _item.Name;
        _icon.sprite = _item.Icon;
        _cost.text = _item.Cost.ToString();
    }

    private void OnPurchaseButtonClicked()
    {
        Clicked?.Invoke(_item);
    }
}
