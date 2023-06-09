using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinStatsDisplay : MonoBehaviour
{
    [SerializeField] private Slider _forceSlider;
    [SerializeField] private Slider _accuracySlider;
    [SerializeField] private Slider _luckSlider;
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
        float force = _skin.GetForce();
        float accuracy = _skin.GetAccuracy();
        float luck = _skin.GetLuck();

        _forceSlider.value = force;
        _accuracySlider.value = accuracy;
        _luckSlider.value = luck;

        _forceText.text = GetFormattedStat(force);
        _accuracyText.text = GetFormattedStat(accuracy);
        _luckText.text = GetFormattedStat(luck);
    }

    private string GetFormattedStat(float value)
    {
        float roundedValue = Mathf.RoundToInt(value * 100) / 10f;
        return $"{GetSign(roundedValue)} {Mathf.Abs(roundedValue)}";
    }

    public string GetSign(float value)
    {
        if (value > 0)
        {
            return "+";
        }

        if (value < 0)
        {
            return "-";
        }

        return "";
    }
}
