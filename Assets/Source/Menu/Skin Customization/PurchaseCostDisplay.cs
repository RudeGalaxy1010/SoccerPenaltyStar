using TMPro;
using UnityEngine;

public class PurchaseCostDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;

    public void Display(int cost)
    {
        _costText.gameObject.SetActive(true);
        _costText.text = cost.ToString();
    }

    public void Hide()
    {
        _costText.gameObject.SetActive(false);
    }
}
