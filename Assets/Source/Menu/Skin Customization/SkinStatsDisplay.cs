using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinStatsDisplay : MonoBehaviour
{
    [SerializeField] private Slider _forceSlider;
    [SerializeField] private Slider _accuracySlider;
    [SerializeField] private Slider _luckSlider;

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
    }
}
