using TMPro;
using UnityEngine;

public class SkinStatsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _forceText;
    [SerializeField] private TMP_Text _accuracyText;
    [SerializeField] private TMP_Text _luckText;

    private Skin _skin;

    public void Construct(Skin skin)
    {
        _skin = skin;
        _skin.Changed += OnSkinChanged;
    }

    private void OnDestroy()
    {
        if (_skin != null)
        {
            _skin.Changed -= OnSkinChanged;
        }
    }

    private void OnSkinChanged()
    {
        DisplayFormat(_forceText, _skin.GetForce());
        DisplayFormat(_accuracyText, _skin.GetAccuracy());
        DisplayFormat(_luckText, _skin.GetLuck());
    }

    private void DisplayFormat(TMP_Text text, float value)
    {
        string valueFormat = value > 0 ? $"+{value}" : $"{value}";
        text.text = valueFormat;
    }
}
