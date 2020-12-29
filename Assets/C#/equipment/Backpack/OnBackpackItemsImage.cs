using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBackpackItemsImage : MonoBehaviour
{
    private Text titleText; //名字/标题
    private Image icoImage; //图标
    private Text contentText; //描述
    private InputField inputField; //输入框

    private Equipment temporaryInventoryEquipment;
    private void Awake()
    {
        titleText = transform.Find("TitleText").GetComponent<Text>();
        icoImage = transform.Find("Image").GetComponent<Image>();
        contentText = transform.Find("Text").GetComponent<Text>();
        inputField = transform.Find("InputField").GetComponent<InputField>();
    }

    /// <summary>
    /// 更新消耗品面板
    /// </summary>
    /// <param name="equipment"></param>
    public void OnUpdateEquipmentBgImage(Equipment equipment)
    {
        //throw new NotImplementedException();
        titleText.text = equipment.equipmentInformation.NameString;
        Sprite sprite = Resources.Load<Sprite>("Image/mainmenu/" + equipment.equipmentInformation.IconString);
        icoImage.sprite = sprite;
        contentText.text = equipment.equipmentInformation.DescribeString;

        temporaryInventoryEquipment = equipment;
    }

    /// <summary>
    /// 关闭面板
    /// </summary>
    public void OnShutdownButton()
    {
        transform.gameObject.SetActive(false);
    }

    //使用功能

    //批量使用功能
}
