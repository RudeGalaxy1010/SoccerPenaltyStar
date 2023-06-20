using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    private Init initSDK;
    public event Action<ShopItem> Clicked;

    [SerializeField] private Button _purchaseButton;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _cost;

    private ShopItem _item;

    private void OnEnable()
    {
        _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
        initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
    }

    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnPurchaseButtonClicked);
        initSDK = null;
    }

    public void SetItem(ShopItem shopItem)
    {
        _item = shopItem;
        _name.text = _item.Name;
        _icon.sprite = _item.Icon;
        _cost.text = _item.Cost.ToString() + " YAN";
    }

    private void OnPurchaseButtonClicked()
    {
        Debug.Log("Покупка");
        initSDK.shopItemView = this;

        string s = "";
        if (_name.text == "+500")
        {
            s = "500";
        }
        else if (_name.text == "+1000")
        {
            s = "1000";
        }
        else if (_name.text == "+5000")
        {
            s = "5000";
        }
        else if (_name.text == "+10000")
        {
            s = "10000";
        }

        else if (_name.text == "+100$")
        {
            s = "100d";
        }
        else if (_name.text == "+500$")
        {
            s = "500d";
        }
        else if (_name.text == "+1000$")
        {
            s = "1000d";
        }
        else if (_name.text == "+3000$")
        {
            s = "3000d";
        }
        initSDK.RealBuyItem(s);
    }

    public void ItemBought()
    {
        Clicked?.Invoke(_item);
    }
}
