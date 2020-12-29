using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBay : MonoBehaviour
{
    private Image headImage; //头像
    private Text nameText; //名字
    private Text levelText; //等级
    private Image energyImage; //生命值
    private Image toughenImage; //魔法值
    private Text energyText;
    private Text toughenText;
    private Button energyPlusButton; //生命值按钮
    private Button toughenPlusButton; //魔法值按钮
    public void OnPlayerInfoChanged(InfoType type)//更新面板信息，当信息发生改变时
    {
        if (type == InfoType.all || type == InfoType.head || type == InfoType.name || type == InfoType.level || type == InfoType.hp || type == InfoType.mp)
        {
            UpdateSHow();
        }
    }
    private void Awake()
    {
        headImage = transform.Find("headSpirte").GetComponent<Image>();
        nameText = transform.Find("TextID").GetComponent<Text>();
        levelText = transform.Find("TextLv").GetComponent<Text>();
        energyImage = transform.Find("lasteBgHp/proger").GetComponent<Image>();
        toughenImage = transform.Find("lasteBgMp/proger").GetComponent<Image>();
        energyPlusButton = transform.Find("ButtonHP").GetComponent<Button>();
        toughenPlusButton = transform.Find("ButtonMP").GetComponent<Button>();
        //energyImage.fillAmount = 0.5f;
        energyText = transform.Find("lasteBgHp/Text").GetComponent<Text>();
        toughenText = transform.Find("lasteBgMp/Text").GetComponent<Text>();

        //PlayerInfo.playerInfonstance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;//原来用事件调用，但没办法，老是报错：没有实力化对象
    }

    private void Start()
    {
        UpdateSHow();//原来用事件调用，但没办法，老是报错：没有实力化对象
    }

    private void OnDestroy()
    {
        //PlayerInfo.playerInfonstance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;//原来用事件调用，但没办法，老是报错：没有实力化对象
    }

    public void UpdateSHow()//更新显示
    {
        PlayerInfo info = PlayerInfo.playerInfonstance;
        headImage.overrideSprite = Resources.Load(info.HeadPortralt, typeof(Sprite)) as Sprite;
        nameText.text = info.Name;
        levelText.text = info.Level.ToString(); //等级
        energyImage.fillAmount = info.Energy / 100f; //生命值
        toughenImage.fillAmount = info.Toughen / 100f; //魔法值
        energyText.text = info.Energy / 100f + "%";
        toughenText.text = info.Toughen / 100f + "%";
    }

    public void OnNameText(string name)
    {
        nameText.text = name;
    }
}