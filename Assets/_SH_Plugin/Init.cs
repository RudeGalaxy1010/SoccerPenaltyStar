using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Init : MonoBehaviour
{
    [Header("Purchased")]
    public ShopItemView shopItemView;

    [Header("Rewarded")]
    public SkinPartsUnlocker skinPartsUnlocker;
    public FreeCoins freeCoins;
    string rewardTag;

    [Header("Localization")]
    public string language;

    [Header("Save")]
    public PlayerData _saveData;
    bool wasLoad;

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern string GetDomain();
    string developerName = "GeeKid%20-%20школа%20программирования";

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern string GetLang();

    [DllImport("__Internal")]
    private static extern void AdInterstitial();

    [DllImport("__Internal")]
    private static extern void AdReward();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value, string leaderboardName);


    public bool mobile;
    private bool adOpen;

    [DllImport("__Internal")]
    private static extern void BuyItem(string idOrTag);

    [DllImport("__Internal")]
    private static extern void CheckBuyItem(string idOrTag);

    string purchasedTag;

    public void ItIsMobile()
    {
        mobile = true;
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Init");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>LOAD YANDEX</color>");
          Debug.Log($"<color=yellow>?MOBILE? YANDEX</color>");
          language = "tr";
          Localization();
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
          //Debug.Log("Load");
          language = GetLang();
          LoadExtern();
#endif
    }

    //РЕКЛАМА//
    public void ShowInterstitialAd()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>INTERSTITIAL SHOW YANDEX</color>");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
          AdInterstitial();
#endif
    }

    public void ShowRewardedAd(string idOrTag)
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>REWARD SHOW YANDEX</color>");
          rewardTag = idOrTag;
          OnRewarded();
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
          rewardTag = idOrTag;
          AdReward();
#endif
    }

    public void OnRewarded()
    {
        if (rewardTag == "Coins")
        {
            freeCoins.PlusCoins();
        }
        else if (rewardTag == "Skin")
        {
            skinPartsUnlocker.BuySkinForAd();
        }
        Debug.Log($"<color=yellow>REWARD YANDEX:</color> {rewardTag}");
    }
    //РЕКЛАМА//


    //ПАУЗА И ПРОДОЛЖЕНИЕ//
    public void StopMusAndGame()
    {
        adOpen = true;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    public void ResumeMusAndGame()
    {
        adOpen = false;
        AudioListener.volume = 1;
        Time.timeScale = 1;
    }
    //ПАУЗА И ПРОДОЛЖЕНИЕ//



    //ЛОКАЛИЗАЦИЯ//
    public void Localization()
    {
        //localScene = GameObject.FindGameObjectWithTag("Localization").GetComponent<LocalizationScene>();
        //localScene.init = this;
        //localScene.Local();
    }
    //ЛОКАЛИЗАЦИЯ//



    //КНОПКА ДРУГИЕ ИГРЫ//
    public void OpenOtherGames()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>OPEN OTHER GAMES YANDEX</color>");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
          var domain = GetDomain();
          Application.OpenURL($"https://yandex.{domain}/games/developer?name=" + developerName);
#endif
    }
    //КНОПКА ДРУГИЕ ИГРЫ//



    //ОТЗЫВЫ//
    public void RateGameFunc()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>REWIEV GAME YANDEX</color>");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
          RateGame();
#endif
    }
    //ОТЗЫВЫ//



    //СОХРАНЕНИЕ И ЗАГРУЗКА//
    public void Save()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>SAVE YANDEX</color>");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
            if (wasLoad)
            {   
                //_saveData = PlayerDataContainer.Instance.Data;
                _saveData = DataHolder.PlayerData;
                string jsonString = JsonUtility.ToJson(_saveData);
                SaveExtern(jsonString);
                Debug.Log("Save");
                Leaderboard("Rating", DataHolder.PlayerData.PlayerRating);
                Debug.Log(DataHolder.PlayerData.PlayerRating);
            }
#endif
    }

    public void SetPlayerData(string value)
    {
        _saveData = JsonUtility.FromJson<PlayerData>(value);
        DataHolder.PlayerData = _saveData;
        //PlayerData._data = _saveData;
        wasLoad = true;
    }

    public void Load()
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>LOAD YANDEX</color>");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
        LoadExtern();
#endif
    }
    //СОХРАНЕНИЕ И ЗАГРУЗКА//



    //ВНУТРИИГРОВЫЕ ПОКУПКИ
    public void RealBuyItem(string idOrTag) //открыть окно покупки
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          purchasedTag = idOrTag;
          OnPurchasedItem();
          Debug.Log($"<color=yellow>PURCHASE YANDEX: </color> {purchasedTag}");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
            purchasedTag = idOrTag;
            BuyItem(idOrTag);
#endif
    }

    public void CheckBuysOnStart(string idOrTag) //проверить покупки на старте
    {
        CheckBuyItem(idOrTag);
    }

    private void OnPurchasedItem() //начислить покупку (при удачной оплате)
    {
        //if (purchasedTag == "purchasedID")
        //{
            shopItemView.ItemBought();
        //}
    }

    public void SetPurchasedItem() //начислить уже купленные предметы на старте
    {
        if (purchasedTag == "purchasedID")
        {
            
        }
    }
    //ВНУТРИИГРОВЫЕ ПОКУПКИ



    //ЛИДЕРБОРД
    public void Leaderboard(string leaderboardName, int value)
    {
#if UNITY_EDITOR && !UNITY_WEBGL
          Debug.Log($"<color=yellow>SET LEADERBOARD YANDEX:</color> {value}");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
            SetToLeaderboard(value, leaderboardName);
#endif
    }
    //ЛИДЕРБОРД


    //ЗВУК И ПАУЗА ПРИ СВОРАЧИВАНИИ
    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        // Or / And
        AudioListener.volume = silence ? 0 : 1;
        Time.timeScale = silence ? 0 : 1;

        if (adOpen)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
    }
    //ЗВУК И ПАУЗА ПРИ СВОРАЧИВАНИИ


    //СБРОС СОХРАНЕНИЙ
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            _saveData = new PlayerData();
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Leaderboard();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }*/
    }
    //СБРОС СОХРАНЕНИЙ
}