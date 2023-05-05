using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BotSelectingText : MonoBehaviour
{
    private const float TextChangeTime = 0.5f;
    private const string BotSelectedText = "Opponent found";
    private readonly string[] SelectingTexts = new string[]
    {
        "Searching for opponent",
        "Searching for opponent.",
        "Searching for opponent..",
        "Searching for opponent...",
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
        _botSelectingText.text = BotSelectedText;
    }

    private IEnumerator ChangeText(float textChangeTime)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(textChangeTime);
        int textIndex = 0;
        _botSelectingTextScaleAnimation.PlayOnce();

        while (true)
        {
            if (textIndex >= SelectingTexts.Length)
            {
                textIndex = 0;
            }

            _botSelectingText.text = SelectingTexts[textIndex];
            textIndex++;
            yield return waitForSeconds;
        }
    }
}
