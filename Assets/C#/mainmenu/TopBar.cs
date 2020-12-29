using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class TopBar : MonoBehaviour
{
    private Text coinText;
    private Text diamondText;
    private Button coinButton;
    private Button diamondButton;
    private void Awake()
    {
        coinText = transform.Find("CoinBg/Text").GetComponent<Text>();
        diamondText = transform.Find("DiomondBg/Text").GetComponent<Text>();
        coinButton = transform.Find("CoinBg/Button").GetComponent<Button>();
        diamondButton = transform.Find("DiomondBg/Button").GetComponent<Button>();
    }
}