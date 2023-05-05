using System;
using UnityEngine;
using UnityEngine.UI;

public class SkinButtons : MonoBehaviour
{
    [SerializeField] private Button _previousColorButton;
    [SerializeField] private Button _nextColorButton;
    [SerializeField] private Button _previousBodyButton;
    [SerializeField] private Button _nextBodyButton;
    [SerializeField] private Button _previousEyesButton;
    [SerializeField] private Button _nextEyesButton;
    [SerializeField] private Button _previousGlovesButton;
    [SerializeField] private Button _nextGlovesButton;
    [SerializeField] private Button _previousHeadButton;
    [SerializeField] private Button _nextHeadButton;
    [SerializeField] private Button _previousMouthButton;
    [SerializeField] private Button _nextMouthButton;
    [SerializeField] private Button _previousNoseButton;
    [SerializeField] private Button _nextNoseButton;
    [SerializeField] private Button _previousHatButton;
    [SerializeField] private Button _nextHatButton;
    [SerializeField] private Button _previousTailButton;
    [SerializeField] private Button _nextTailButton;
    [SerializeField] private Button _randomSkinButton;

    private SkinCustomization _skin;

    public void Construct(SkinCustomization skinCustomization)
    {
        _skin = skinCustomization;
    }

    private void OnEnable()
    {
        _previousColorButton.onClick.AddListener(OnPreviousColorButtonClicked);
        _previousBodyButton.onClick.AddListener(OnPreviousBodyButtonClicked);
        _previousEyesButton.onClick.AddListener(OnPreviousEyesButtonClicked);
        _previousGlovesButton.onClick.AddListener(OnPreviousGlovesButtonClicked);
        _previousHeadButton.onClick.AddListener(OnPreviousHeadButtonClicked);
        _previousMouthButton.onClick.AddListener(OnPreviousMouthButtonClicked);
        _previousNoseButton.onClick.AddListener(OnPreviousNoseButtonClicked);
        _previousHatButton.onClick.AddListener(OnPreviousHatButtonClicked);
        _previousTailButton.onClick.AddListener(OnPreviousTailButtonClicked);

        _nextColorButton.onClick.AddListener(OnNextColorButtonClicked);
        _nextBodyButton.onClick.AddListener(OnNextBodyButtonClicked);
        _nextEyesButton.onClick.AddListener(OnNextEyesButtonClicked);
        _nextGlovesButton.onClick.AddListener(OnNextGlovesButtonClicked);
        _nextHeadButton.onClick.AddListener(OnNextHeadButtonClicked);
        _nextMouthButton.onClick.AddListener(OnNextMouthButtonClicked);
        _nextNoseButton.onClick.AddListener(OnNextNoseButtonClicked);
        _nextHatButton.onClick.AddListener(OnNextHatButtonClicked);
        _nextTailButton.onClick.AddListener(OnNextTailButtonClicked);

        _randomSkinButton.onClick.AddListener(OnRandomSkinButtonClicked);
    }

    private void OnDisable()
    {
        _previousColorButton.onClick.RemoveListener(OnPreviousColorButtonClicked);
        _previousBodyButton.onClick.RemoveListener(OnPreviousBodyButtonClicked);
        _previousEyesButton.onClick.RemoveListener(OnPreviousEyesButtonClicked);
        _previousGlovesButton.onClick.RemoveListener(OnPreviousGlovesButtonClicked);
        _previousHeadButton.onClick.RemoveListener(OnPreviousHeadButtonClicked);
        _previousMouthButton.onClick.RemoveListener(OnPreviousMouthButtonClicked);
        _previousNoseButton.onClick.RemoveListener(OnPreviousNoseButtonClicked);
        _previousHatButton.onClick.RemoveListener(OnPreviousHatButtonClicked);
        _previousTailButton.onClick.RemoveListener(OnPreviousTailButtonClicked);

        _nextColorButton.onClick.RemoveListener(OnNextColorButtonClicked);
        _nextBodyButton.onClick.RemoveListener(OnNextBodyButtonClicked);
        _nextEyesButton.onClick.RemoveListener(OnNextEyesButtonClicked);
        _nextGlovesButton.onClick.RemoveListener(OnNextGlovesButtonClicked);
        _nextHeadButton.onClick.RemoveListener(OnNextHeadButtonClicked);
        _nextMouthButton.onClick.RemoveListener(OnNextMouthButtonClicked);
        _nextNoseButton.onClick.RemoveListener(OnNextNoseButtonClicked);
        _nextHatButton.onClick.RemoveListener(OnNextHatButtonClicked);
        _nextTailButton.onClick.RemoveListener(OnNextTailButtonClicked);

        _randomSkinButton.onClick.RemoveListener(OnRandomSkinButtonClicked);
    }

    private void OnPreviousColorButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Color);
    }

    private void OnPreviousBodyButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Body);
    }

    private void OnPreviousEyesButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Eyes);
    }

    private void OnPreviousGlovesButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Gloves);
    }

    private void OnPreviousHeadButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Head);
    }

    private void OnPreviousMouthButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Mouth);
    }

    private void OnPreviousNoseButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Nose);
    }

    private void OnPreviousHatButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Hat);
    }

    private void OnPreviousTailButtonClicked()
    {
        _skin.SetPreviousPart(CustomizationPart.Tail);
    }

    private void OnNextColorButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Color);
    }

    private void OnNextBodyButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Body);
    }

    private void OnNextEyesButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Eyes);
    }

    private void OnNextGlovesButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Gloves);
    }

    private void OnNextHeadButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Head);
    }

    private void OnNextMouthButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Mouth);
    }

    private void OnNextNoseButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Nose);
    }

    private void OnNextHatButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Hat);
    }

    private void OnNextTailButtonClicked()
    {
        _skin.SetNextPart(CustomizationPart.Tail);
    }

    private void OnRandomSkinButtonClicked()
    {
        _skin.ApplyRandom();
    }
}
