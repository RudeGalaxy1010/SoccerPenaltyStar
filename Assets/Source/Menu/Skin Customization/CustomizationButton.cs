using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationButton : MonoBehaviour
{
    [SerializeField] private Button _customizationButton;
    [SerializeField] private GameObject _customimzationPanel;

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
        _customimzationPanel.SetActive(!_customimzationPanel.activeInHierarchy);
    }
}
