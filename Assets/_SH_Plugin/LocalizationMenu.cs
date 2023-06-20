using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationMenu : MonoBehaviour
{
	private Init initSDK;

	[Header("Menu")]
    [SerializeField] private TextMeshProUGUI forceTxt;
    [SerializeField] private TextMeshProUGUI accuracyTxt;
    [SerializeField] private TextMeshProUGUI luckTxt;
    [SerializeField] private TextMeshProUGUI freeCoinsTxt;

    [SerializeField] private TextMeshProUGUI leaderboardTxt;
    [SerializeField] private TextMeshProUGUI customizationTxt;
    [SerializeField] private TextMeshProUGUI shopTxt;

    [SerializeField] private TextMeshProUGUI readyTxt;

    [Header("Customization")]
    [SerializeField] private TextMeshProUGUI colorText;
    [SerializeField] private TextMeshProUGUI accessoriesText;
    [SerializeField] private TextMeshProUGUI eyesText;
    [SerializeField] private TextMeshProUGUI glovesText;
    [SerializeField] private TextMeshProUGUI headText;
    [SerializeField] private TextMeshProUGUI mouthText;
    [SerializeField] private TextMeshProUGUI noseText;
    [SerializeField] private TextMeshProUGUI tailText;
    [SerializeField] private TextMeshProUGUI purchaseText;

    [Header("Shop")]
    [SerializeField] private TextMeshProUGUI coinsShopText;
    [SerializeField] private TextMeshProUGUI dollarsShopText;

    [Header("Other")]
    [SerializeField] private TextMeshProUGUI youText;
    [SerializeField] private TextMeshProUGUI multiplayerText;

    void Start()
    {
    	initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
    	if (initSDK.language == "ru")
    	{
    		forceTxt.text = "Сила";
		    accuracyTxt.text = "Ловкость";
		    luckTxt.text = "Удача";
		    freeCoinsTxt.text = "Больше монет(реклама)";

		    leaderboardTxt.text = "Таблица лидеров";
		    customizationTxt.text = "Кастомизация";
		    shopTxt.text = "Магазин";

		    readyTxt.text = "Готов";

		    colorText.text = "Цвет";
		    accessoriesText.text = "Аксессуары";
		    eyesText.text = "Глаза";
		    glovesText.text = "Перчатки";
		    headText.text = "Голова";
		    mouthText.text = "Рот";
		    noseText.text = "Нос";
		    tailText.text = "Хвост";

		    coinsShopText.text = "Магазин монет";
		    dollarsShopText.text = "Маазин долларов";

		    youText.text = "Вы";
		    multiplayerText.text = "";
		    purchaseText.text = "Купить";
    	}
    	else if (initSDK.language == "en")
    	{
    		forceTxt.text = "Force";
		    accuracyTxt.text = "Accuracy";
		    luckTxt.text = "Luck";
		    freeCoinsTxt.text = "Free Coins (AD)";

		    leaderboardTxt.text = "Leaderboard";
		    customizationTxt.text = "Customization";
		    shopTxt.text = "Shop";

		    readyTxt.text = "Ready";

		    colorText.text = "Color";
		    accessoriesText.text = "Accessories";
		    eyesText.text = "Eyes";
		    glovesText.text = "Gloves";
		    headText.text = "Head";
		    mouthText.text = "Mouth";
		    noseText.text = "Nose";
		    tailText.text = "Tail";

		    coinsShopText.text = "Coins Shop";
		    dollarsShopText.text = "Dollars Shop";

		    youText.text = "You";
		    multiplayerText.text = "Searching for opponent";
		    purchaseText.text = "Purchase";
    	}
    	else if (initSDK.language == "tr")
    	{
    		forceTxt.text = "Kuvvet";
		    accuracyTxt.text = "Doğruluk";
		    luckTxt.text = "Şans";
		    freeCoinsTxt.text = "Ücretsiz Paralar (AD)";

		    leaderboardTxt.text = "Skor Tablosu";
		    customizationTxt.text = "Özelleştirme";
		    shopTxt.text = "Dükkan";

		    readyTxt.text = "Hazır";

		    colorText.text = "Renk";
		    accessoriesText.text = "Aksesuarlar";
		    eyesText.text = "Gözler";
		    glovesText.text = "Eldivenler";
		    headText.text = "Baş";
		    mouthText.text = "Ağız";
		    noseText.text = "Burun";
		    tailText.text = "Kuyruk";

		    coinsShopText.text = "Para Dükkanı";
		    dollarsShopText.text = "Dolar Dükkanı";
		    youText.text = "Sen";
		    multiplayerText.text = "Rakip aranıyor";
		    purchaseText.text = "Satın almak";
    	}
    }
}
