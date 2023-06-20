using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeCoins : MonoBehaviour
{
    [SerializeField] private Button _freeCoinsButton;
    private Init initSDK;

    private Coins _coins;

    public void Construct(Coins coins)
    {
        _coins = coins;
    }

    private void OnEnable()
    {
        _freeCoinsButton.onClick.AddListener(OnFreeCoinsButtonClicked);
        initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
    }

    private void OnDisable()
    {
        _freeCoinsButton.onClick.RemoveListener(OnFreeCoinsButtonClicked);
        initSDK = null;
    }

    private void OnFreeCoinsButtonClicked()
    {
        initSDK.freeCoins = this;
        initSDK.ShowRewardedAd("Coins");
    }

    public void PlusCoins()
    {
        _coins.AddFreeMoney();
    }
}
