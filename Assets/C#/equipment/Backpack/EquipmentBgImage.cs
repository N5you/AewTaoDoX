using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentBgImage : MonoBehaviour
{
    private Image icoImage; //图标
    private Text nameText; //名字
    private Text qualityText; //品质
    private Text damageText; //伤害
    private Text hpText; //生命
    private Text contentText; //描述
    private Text effectivenessText; //战斗力

    private Equipment temporaryInventoryEquipment;

    //private RoleImage roleImage; //穿戴装备面板
    private InventoryEquipment inventoryEquipment; //背包面板

    //public Sprite sprite;
    public Equipment TemporaryInventoryEquipment
    {
        get { return temporaryInventoryEquipment; }
        set { temporaryInventoryEquipment = value; }
    }
    private void Awake()
    {
        icoImage = transform.Find("Image").GetComponent<Image>();
        nameText = transform.Find("NameText").GetComponent<Text>();
        qualityText = transform.Find("QualityText/Text").GetComponent<Text>();
        damageText = transform.Find("DamageText/Text").GetComponent<Text>();
        hpText = transform.Find("HpText/Text").GetComponent<Text>();
        contentText = transform.Find("Text").GetComponent<Text>();
        effectivenessText = transform.Find("EffectivenessText/Text").GetComponent<Text>();

        //roleImage = transform.parent.Find("RoleImage").GetComponent<RoleImage>();
        inventoryEquipment = transform.parent.GetComponent<InventoryEquipment>();
    }
    /// <summary>
    /// 更新面板内容
    /// </summary>
    /// <param name="equipment">背包中的物品</param>
    public void OnUpdateEquipmentBgImage(Equipment equipment)
    {
        Sprite sprite = Resources.Load<Sprite>("Image/mainmenu/" + equipment.equipmentInformation.IconString);
        //icoImage.sprite = Resources.Load<Sprite>("Image/mainmenu" + );
        icoImage.sprite = sprite;
        //Debug.Log(equipment.equipmentInformation.IconString);
        nameText.text = equipment.equipmentInformation.NameString;
        qualityText.text = equipment.equipmentInformation.QualityInt.ToString();
        damageText.text = equipment.equipmentInformation.DamageInt.ToString();
        hpText.text = equipment.equipmentInformation.HpInt.ToString();
        contentText.text = equipment.equipmentInformation.DescribeString;
        effectivenessText.text = equipment.equipmentInformation.EffectivenessInt.ToString();

        temporaryInventoryEquipment = equipment;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    public void OnShutdownButton()
    {
        transform.gameObject.SetActive(false);
    }



}