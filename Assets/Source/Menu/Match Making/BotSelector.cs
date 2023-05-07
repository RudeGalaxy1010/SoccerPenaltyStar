using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BotSelector : MonoBehaviour
{
    public event Action BotSelected;

    private const int MinBotsChanges = 7;
    private const int MaxBotsChanges = 12;
    private const float SelectingTime = 5f;
    private const int MaxBotRatingDifference = 45;

    private Transform _botSpawnPoint;
    private TMP_Text _botNickText;
    private RatingDisplay _ratingDisplay;

    public void Construct(Transform botSpawnPoint, TMP_Text botNickText, RatingDisplay ratingDisplay)
    {
        _botSpawnPoint = botSpawnPoint;
        _botNickText = botNickText;
        _ratingDisplay = ratingDisplay;
        _botNickText.gameObject.SetActive(false);
    }

    public void StartSelectingBot()
    {
        Skin skin = CreateBot();
        int botsChanges = GetBotsChanges();
        StartCoroutine(SelectBot(botsChanges, _botNickText, skin));
        _botNickText.gameObject.SetActive(true);
    }

    private Skin CreateBot()
    {
        Skin skin = Instantiate(GamePrefabs.SkinPrefab, _botSpawnPoint.position, 
            _botSpawnPoint.rotation, _botSpawnPoint);
        skin.Apply(DataHolder.PlayerData.BotSkinData);
        ChangeBot(_botNickText, skin);
        return skin;
    }

    private IEnumerator SelectBot(int botsChanges, TMP_Text nickText, Skin skin)
    {
        for (int i = 0; i < botsChanges; i++)
        {
            ChangeBot(nickText, skin);
            yield return new WaitForSeconds(GetNextBotChangeTime(botsChanges));
        }

        BotSelected?.Invoke();
    }

    private void ChangeBot(TMP_Text nickText, Skin skin)
    {
        nickText.text = NickNameGenerator.GetRandomName();
        _ratingDisplay.DisplayBotRating(GetRandomBotRating());
        skin.ApplyRandom();
        DataHolder.PlayerData.BotSkinData = skin.SkinData;
    }

    private int GetRandomBotRating()
    {
        int minRating = Mathf.Max(0, DataHolder.PlayerData.PlayerRating - MaxBotRatingDifference);
        int maxRating = DataHolder.PlayerData.PlayerRating + MaxBotRatingDifference;
        return UnityEngine.Random.Range(minRating, maxRating);
    }

    private int GetBotsChanges()
    {
        return UnityEngine.Random.Range(MinBotsChanges, MaxBotsChanges);
    }

    private float GetNextBotChangeTime(int botsChanges)
    {
        return SelectingTime / botsChanges;
    }
}
