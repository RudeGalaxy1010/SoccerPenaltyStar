using System;
using System.Collections;
using UnityEngine;

public class MatchMaker : MonoBehaviour
{
    private const float StartDelay = 1.5f;

    public event Action MatchMakingStarted;

    private BotSelector _botSelector;
    private LevelLoader _levelLoader;

    public void Construct(BotSelector botSelector, LevelLoader levelLoader)
    {
        _botSelector = botSelector;
        _levelLoader = levelLoader;
        _botSelector.BotSelected += OnBotSelected;
    }

    public void StartSelectingBot()
    {
        MatchMakingStarted?.Invoke();
        _botSelector.StartSelectingBot();
    }

    private void OnBotSelected()
    {
        StartCoroutine(WaitAndStart(StartDelay));
    }

    private IEnumerator WaitAndStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _levelLoader.LoadGame();
    }

    private void OnDestroy()
    {
        if (_botSelector != null)
        {
            _botSelector.BotSelected -= OnBotSelected;
        }
    }
}
