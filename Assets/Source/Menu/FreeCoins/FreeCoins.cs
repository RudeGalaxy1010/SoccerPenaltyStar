using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeCoins : MonoBehaviour
{
    [SerializeField] private Button _freeCoinsButton;

    private Coins _coins;

    public void Construct(Coins coins)
    {
        _coins = coins;
    }

    private void OnEnable()
    {
        _freeCoinsButton.onClick.AddListener(OnFreeCoinsButtonClicked);
    }

    private void OnDisable()
    {
        _freeCoinsButton.onClick.RemoveListener(OnFreeCoinsButtonClicked);
    }

    private void OnFreeCoinsButtonClicked()
    {
        // TODO: Call ADs function
        _coins.AddFreeMoney();
    }
}
