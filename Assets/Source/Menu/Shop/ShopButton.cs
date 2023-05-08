using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private GameObject _shopPanel;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OnShopButtonClicked);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
    }

    private void OnShopButtonClicked()
    {
        _shopPanel.SetActive(!_shopPanel.activeInHierarchy);
    }
}
