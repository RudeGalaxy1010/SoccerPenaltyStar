using TMPro;
using UnityEngine;

public class PurchaseCostDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _dollarsText;
    [SerializeField] private TMP_Text _adsText;
    [SerializeField] private GameObject _texts;
    [SerializeField] private GameObject _icons;

    public void Display(int coins, int dollars, int ads)
    {
        _texts.SetActive(true);
        _icons.SetActive(true);

        if (coins > 0)
        {
            _coinsText.text = coins.ToString();
        }
        if (dollars > 0)
        {
            _dollarsText.text = dollars.ToString();
        }
        if (ads > 0)
        {
            _adsText.text = ads.ToString();
        }
    }

    public void Hide()
    {
        _texts.SetActive(false);
        _icons.SetActive(false);
    }
}
