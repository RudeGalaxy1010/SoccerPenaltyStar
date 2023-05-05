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

    private readonly string[] Nicks = new string[] { "John", "Doe", "The_bot" };

    private Transform _botSpawnPoint;
    private TMP_Text _botNickText;
    private int _lastNickIndex;

    public void Construct(Transform botSpawnPoint, TMP_Text botNickText)
    {
        _botSpawnPoint = botSpawnPoint;
        _botNickText = botNickText;
        _botNickText.gameObject.SetActive(false);
    }

    public void StartSelectingBot()
    {
        SkinCustomization skin = CreateBot();
        int botsChanges = GetBotsChanges();
        StartCoroutine(SelectBot(botsChanges, _botNickText, skin));
        _botNickText.gameObject.SetActive(true);
    }

    private SkinCustomization CreateBot()
    {
        SkinCustomization skin = Instantiate(GamePrefabs.SkinPrefab, _botSpawnPoint.position, 
            _botSpawnPoint.rotation, _botSpawnPoint);
        skin.Apply(DataHolder.PlayerData.BotSkinCustomizationData);
        ChangeBot(_botNickText, skin);
        return skin;
    }

    private IEnumerator SelectBot(int botsChanges, TMP_Text nickText, SkinCustomization skin)
    {
        for (int i = 0; i < botsChanges; i++)
        {
            ChangeBot(nickText, skin);
            yield return new WaitForSeconds(GetNextBotChangeTime(botsChanges));
        }

        BotSelected?.Invoke();
    }

    private void ChangeBot(TMP_Text nickText, SkinCustomization skin)
    {
        nickText.text = GetRandomNick();
        skin.ApplyRandom();
    }

    private string GetRandomNick()
    {
        int index = _lastNickIndex;
        
        while (index == _lastNickIndex)
        {
            index = UnityEngine.Random.Range(0, Nicks.Length);
        }

        _lastNickIndex = index;
        return Nicks[index];
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
