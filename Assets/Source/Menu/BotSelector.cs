using System;
using System.Collections;
using UnityEngine;

public class BotSelector : MonoBehaviour
{
    public event Action BotSelected;

    private const int MinBotsChanges = 7;
    private const int MaxBotsChanges = 12;
    private const float SelectingTime = 5f;

    private Transform _botSpawnPoint;

    public void Construct(Transform botSpawnPoint)
    {
        _botSpawnPoint = botSpawnPoint;
    }

    public void StartSelectingBot()
    {
        SkinCustomization skin = CreateBot();
        int botsChanges = GetBotsChanges();
        StartCoroutine(SelectBot(botsChanges, skin));
    }

    private SkinCustomization CreateBot()
    {
        SkinCustomization skin = Instantiate(GamePrefabs.SkinPrefab, _botSpawnPoint.position, 
            _botSpawnPoint.rotation, _botSpawnPoint);
        skin.Apply(DataHolder.PlayerData.BotSkinCustomizationData);
        ChangeBot(skin);
        return skin;
    }

    private IEnumerator SelectBot(int botsChanges, SkinCustomization skin)
    {
        for (int i = 0; i < botsChanges; i++)
        {
            ChangeBot(skin);
            yield return new WaitForSeconds(GetNextBotChangeTime(botsChanges));
        }

        BotSelected?.Invoke();
    }

    private void ChangeBot(SkinCustomization skin)
    {
        skin.ApplyRandom();
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
