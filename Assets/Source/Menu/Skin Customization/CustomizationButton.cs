using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationButton : MonoBehaviour
{
    [SerializeField] private Button _customizationButton;
    [SerializeField] private GameObject _customimzationPanel;

    private Skin _skin;
    private SkinPartsUnlocker _skinPartsUnlocker;
    private SkinData _skinData;

    public void Construct(Skin playerSkin, SkinPartsUnlocker skinPartsUnlocker)
    {
        _skin = playerSkin;
        _skinPartsUnlocker = skinPartsUnlocker;
    }

    private void OnEnable()
    {
        _customizationButton.onClick.AddListener(OnCustomizationButtonClicked);
    }

    private void OnDisable()
    {
        _customizationButton.onClick.RemoveListener(OnCustomizationButtonClicked);
    }

    private void OnCustomizationButtonClicked()
    {
        if (_customimzationPanel.activeInHierarchy == false)
        {
            _skinData = DataHolder.PlayerData.PlayerSkinData;
        }
        else if (_skinPartsUnlocker.HasLockedParts == true)
        {
            DataHolder.PlayerData.PlayerSkinData = _skinData;
            _skin.Apply(DataHolder.PlayerData.PlayerSkinData);
        }

        _customimzationPanel.SetActive(!_customimzationPanel.activeInHierarchy);
    }
}
