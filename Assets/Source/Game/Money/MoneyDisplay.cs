using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private IMoney _money;

    public void Construct(IMoney money)
    {
        _money = money;
        _money.Changed += OnMoneyChanged;
        DisplayMoney(_money.Value);
    }

    private void OnDestroy()
    {
        if (_money != null)
        {
            _money.Changed -= OnMoneyChanged;
        }
    }

    private void OnMoneyChanged(float value)
    {
        DisplayMoney(value);
    }

    private void DisplayMoney(float value)
    {
        _moneyText.text = value.ToString();
    }
}
