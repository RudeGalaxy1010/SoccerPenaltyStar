using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private Money _money;

    public void Construct(Money money)
    {
        _money = money;
        _money.MoneyChanged += OnMoneyChanged;
        DisplayMoney(_money.Value);
    }

    private void OnDestroy()
    {
        if (_money != null)
        {
            _money.MoneyChanged -= OnMoneyChanged;
        }
    }

    private void OnMoneyChanged(int value)
    {
        DisplayMoney(value);
    }

    private void DisplayMoney(int value)
    {
        _moneyText.text = value.ToString();
    }
}
