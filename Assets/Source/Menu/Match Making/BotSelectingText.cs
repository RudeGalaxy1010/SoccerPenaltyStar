using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BotSelectingText : MonoBehaviour
{
    private Init initSDK;

    private const float TextChangeTime = 0.5f;
    private const string BotSelectedText = "Opponent found";
    private readonly string[] SelectingTexts = new string[]
    {
        "Searching for opponent",
        "Searching for opponent.",
        "Searching for opponent..",
        "Searching for opponent...",
    };

    private const string BotSelectedTextRus = "Оппонент найден";
    private readonly string[] SelectingTextsRus = new string[]
    {
        "Поиск оппонента",
        "Поиск оппонента.",
        "Поиск оппонента..",
        "Поиск оппонента...",
    };

    private const string BotSelectedTextTur = "Rakip bulundu";
    private readonly string[] SelectingTextsTur = new string[]
    {
        "Rakip aranıyor",
        "Rakip aranıyor.",
        "Rakip aranıyor..",
        "Rakip aranıyor...",
    };

    [SerializeField] private TMP_Text _botSelectingText;
    [SerializeField] private ScaleAnimation _botSelectingTextScaleAnimation;
    [SerializeField] private MatchMaker _matchMaker;

    private Coroutine _textChangingCoroutine;

    private void OnEnable()
    {
        _matchMaker.MatchMakingStarted += OnMatchMakingStarted;
        _matchMaker.MatchMakingFinished += OnMatchMakingFinished;
    }

    private void OnDisable()
    {
        _matchMaker.MatchMakingStarted -= OnMatchMakingStarted;
        _matchMaker.MatchMakingFinished -= OnMatchMakingFinished;
    }

    private void OnMatchMakingStarted()
    {
        _textChangingCoroutine = StartCoroutine(ChangeText(TextChangeTime));
    }

    private void OnMatchMakingFinished()
    {
        StopCoroutine(_textChangingCoroutine);
        if (initSDK.language == "en")
            _botSelectingText.text = BotSelectedText;
        else if (initSDK.language == "ru")
            _botSelectingText.text = BotSelectedTextRus;
        else if (initSDK.language == "tr")
            _botSelectingText.text = BotSelectedTextTur;
    }

    void Start()
    {
        initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
    }

    private IEnumerator ChangeText(float textChangeTime)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(textChangeTime);
        int textIndex = 0;
        _botSelectingTextScaleAnimation.PlayOnce();

        while (true)
        {
            if (initSDK.language == "en")
            {
                if (textIndex >= SelectingTexts.Length)
                {
                    textIndex = 0;
                }

                _botSelectingText.text = SelectingTexts[textIndex];
                textIndex++;
                yield return waitForSeconds;
            }
            else if (initSDK.language == "ru")
            {
                if (textIndex >= SelectingTextsRus.Length)
                {
                    textIndex = 0;
                }

                _botSelectingText.text = SelectingTextsRus[textIndex];
                textIndex++;
                yield return waitForSeconds;
            }
            else if (initSDK.language == "tr")
            {
                if (textIndex >= SelectingTextsTur.Length)
                {
                    textIndex = 0;
                }

                _botSelectingText.text = SelectingTextsTur[textIndex];
                textIndex++;
                yield return waitForSeconds;
            }
        }
    }
}
