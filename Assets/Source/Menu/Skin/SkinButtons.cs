using UnityEngine;
using UnityEngine.UI;

public class SkinButtons : MonoBehaviour
{
    [SerializeField] private Button _previousSkinButton;
    [SerializeField] private Button _nextSkinButton;

    private SkinPicker _skinPicker;

    public void Construct(SkinPicker skinPicker)
    {
        _skinPicker = skinPicker;
    }

    private void OnEnable()
    {
        _nextSkinButton.onClick.AddListener(OnNextSkinButtonClicked);
        _previousSkinButton.onClick.AddListener(OnPreviousSkinButtonClicked);
    }

    private void OnDisable()
    {
        _nextSkinButton.onClick.RemoveListener(OnNextSkinButtonClicked);
        _previousSkinButton.onClick.RemoveListener(OnPreviousSkinButtonClicked);
    }

    private void OnNextSkinButtonClicked()
    {
        _skinPicker.SetNextSkin();
    }

    private void OnPreviousSkinButtonClicked()
    {
        _skinPicker.SetPreviousSkin();
    }
}
