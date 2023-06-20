using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalLocal : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI goalText;
	public Init initSDK;

    void Start()
    {
        initSDK = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
        if (initSDK.language == "ru")
        {
            goalText.text = "*ГОЛ!*";
        }
        else if (initSDK.language == "en")
        {
            goalText.text = "*GOAL!*";
        }
        else if (initSDK.language == "tr")
        {
            goalText.text = "*AMAÇ!*";
        }
    }
}
