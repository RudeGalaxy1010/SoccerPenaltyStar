using UnityEngine;
using UnityEngine.UI;

public class SkinButtons : MonoBehaviour
{
    [SerializeField] private Button _previousColorButton;
    [SerializeField] private Button _nextColorButton;
    [SerializeField] private Button _previousAccessoriesButton;
    [SerializeField] private Button _nextAccessoriesButton;
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
    [SerializeField] private Button _previousTailButton;
    [SerializeField] private Button _nextTailButton;

    [Header("Match Maker")]
    [SerializeField] private MatchMaker _matchMaker;

    private Skin _skin;

    public void Construct(Skin skin)
    {
        _skin = skin;
        Enable();
    }

    private void OnEnable()
    {
        _previousColorButton.onClick.AddListener(OnPreviousColorButtonClicked);
        _previousAccessoriesButton.onClick.AddListener(OnPreviousAccessoriesButtonClicked);
        _previousEyesButton.onClick.AddListener(OnPreviousEyesButtonClicked);
        _previousGlovesButton.onClick.AddListener(OnPreviousGlovesButtonClicked);
        _previousHeadButton.onClick.AddListener(OnPreviousHeadButtonClicked);
        _previousMouthButton.onClick.AddListener(OnPreviousMouthButtonClicked);
        _previousNoseButton.onClick.AddListener(OnPreviousNoseButtonClicked);
        _previousTailButton.onClick.AddListener(OnPreviousTailButtonClicked);

        _nextColorButton.onClick.AddListener(OnNextColorButtonClicked);
        _nextAccessoriesButton.onClick.AddListener(OnNextAccessoriesButtonClicked);
        _nextEyesButton.onClick.AddListener(OnNextEyesButtonClicked);
        _nextGlovesButton.onClick.AddListener(OnNextGlovesButtonClicked);
        _nextHeadButton.onClick.AddListener(OnNextHeadButtonClicked);
        _nextMouthButton.onClick.AddListener(OnNextMouthButtonClicked);
        _nextNoseButton.onClick.AddListener(OnNextNoseButtonClicked);
        _nextTailButton.onClick.AddListener(OnNextTailButtonClicked);

        _matchMaker.MatchMakingStarted += OnMatchMakingStarted;
    }

    private void OnDisable()
    {
        _previousColorButton.onClick.RemoveListener(OnPreviousColorButtonClicked);
        _previousAccessoriesButton.onClick.RemoveListener(OnPreviousAccessoriesButtonClicked);
        _previousEyesButton.onClick.RemoveListener(OnPreviousEyesButtonClicked);
        _previousGlovesButton.onClick.RemoveListener(OnPreviousGlovesButtonClicked);
        _previousHeadButton.onClick.RemoveListener(OnPreviousHeadButtonClicked);
        _previousMouthButton.onClick.RemoveListener(OnPreviousMouthButtonClicked);
        _previousNoseButton.onClick.RemoveListener(OnPreviousNoseButtonClicked);
        _previousTailButton.onClick.RemoveListener(OnPreviousTailButtonClicked);

        _nextColorButton.onClick.RemoveListener(OnNextColorButtonClicked);
        _nextAccessoriesButton.onClick.RemoveListener(OnNextAccessoriesButtonClicked);
        _nextEyesButton.onClick.RemoveListener(OnNextEyesButtonClicked);
        _nextGlovesButton.onClick.RemoveListener(OnNextGlovesButtonClicked);
        _nextHeadButton.onClick.RemoveListener(OnNextHeadButtonClicked);
        _nextMouthButton.onClick.RemoveListener(OnNextMouthButtonClicked);
        _nextNoseButton.onClick.RemoveListener(OnNextNoseButtonClicked);
        _nextTailButton.onClick.RemoveListener(OnNextTailButtonClicked);

        _matchMaker.MatchMakingStarted -= OnMatchMakingStarted;
    }

    private void OnMatchMakingStarted()
    {
        Disable();
    }

    private void Enable()
    {
        _previousColorButton.interactable = true;
        _previousAccessoriesButton.interactable = true;
        _previousEyesButton.interactable = true;
        _previousGlovesButton.interactable = true;
        _previousHeadButton.interactable = true;
        _previousMouthButton.interactable = true;
        _previousNoseButton.interactable = true;
        _previousTailButton.interactable = true;

        _nextColorButton.interactable = true;
        _nextAccessoriesButton.interactable = true;
        _nextEyesButton.interactable = true;
        _nextGlovesButton.interactable = true;
        _nextHeadButton.interactable = true;
        _nextMouthButton.interactable = true;
        _nextNoseButton.interactable = true;
        _nextTailButton.interactable = true;
    }

    private void Disable()
    {
        _previousColorButton.interactable = false;
        _previousAccessoriesButton.interactable = false;
        _previousEyesButton.interactable = false;
        _previousGlovesButton.interactable = false;
        _previousHeadButton.interactable = false;
        _previousMouthButton.interactable = false;
        _previousNoseButton.interactable = false;
        _previousTailButton.interactable = false;

        _nextColorButton.interactable = false;
        _nextAccessoriesButton.interactable = false;
        _nextEyesButton.interactable = false;
        _nextGlovesButton.interactable = false;
        _nextHeadButton.interactable = false;
        _nextMouthButton.interactable = false;
        _nextNoseButton.interactable = false;
        _nextTailButton.interactable = false;
    }

    private void OnPreviousColorButtonClicked()
    {
        _skin.ColorSkinParts.SetPreviousPart();
    }

    private void OnPreviousAccessoriesButtonClicked()
    {
        _skin.AccessoriesSkinParts.SetPreviousPart();
    }

    private void OnPreviousEyesButtonClicked()
    {
        _skin.EyesSkinParts.SetPreviousPart();
    }

    private void OnPreviousGlovesButtonClicked()
    {
        _skin.GlovesSkinParts.SetPreviousPart();
    }

    private void OnPreviousHeadButtonClicked()
    {
        _skin.HeadSkinParts.SetPreviousPart();
    }

    private void OnPreviousMouthButtonClicked()
    {
        _skin.MouthSkinParts.SetPreviousPart();
    }

    private void OnPreviousNoseButtonClicked()
    {
        _skin.NoseSkinParts.SetPreviousPart();
    }

    private void OnPreviousTailButtonClicked()
    {
        _skin.TailSkinParts.SetPreviousPart();
    }

    private void OnNextColorButtonClicked()
    {
        _skin.ColorSkinParts.SetNextPart();
    }

    private void OnNextAccessoriesButtonClicked()
    {
        _skin.AccessoriesSkinParts.SetNextPart();
    }

    private void OnNextEyesButtonClicked()
    {
        _skin.EyesSkinParts.SetNextPart();
    }

    private void OnNextGlovesButtonClicked()
    {
        _skin.GlovesSkinParts.SetPreviousPart();
    }

    private void OnNextHeadButtonClicked()
    {
        _skin.HeadSkinParts.SetNextPart();
    }

    private void OnNextMouthButtonClicked()
    {
        _skin.MouthSkinParts.SetNextPart();
    }

    private void OnNextNoseButtonClicked()
    {
        _skin.NoseSkinParts.SetNextPart();
    }

    private void OnNextTailButtonClicked()
    {
        _skin.TailSkinParts.SetNextPart();
    }
}
