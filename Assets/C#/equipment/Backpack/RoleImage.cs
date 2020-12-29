using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleImage : MonoBehaviour
{
    private Image[] props;
    private Text hpText;
    private Text attackText;
    private Image expImage;
    private Text expText;//ExpBgImage

    public PlayerInfo playerInfo;

    //private Equipment[] propsEquipment;

    private InventoryEquipment inventoryEquipment;
    #region 访问权限
    public Image[] Props
    {
        get { return props; }
        set { props = value; }
    }
    //public Equipment[] PropsEquipment
    //{
    //    get { return propsEquipment; }
    //    set { propsEquipment = value; }
    //}
    #endregion
    private void Awake()
    {
        props= transform.Find("Props").GetComponentsInChildren<Image>();
        //Debug.Log(props.Length);
        hpText = transform.Find("HpText/Text").GetComponent<Text>();
        //hpText.text = "21150";
        attackText = transform.Find("AttackText/Text").GetComponent<Text>();

        expImage = transform.Find("ExpBgImage/ExpImage").GetComponent<Image>();
        expText = transform.Find("ExpBgImage/Text").GetComponent<Text>();

        AllUpdateRole();
        if(playerInfo == null) playerInfo = GameObject.Find("GameController").GetComponent<PlayerInfo>();

        //propsEquipment = new Equipment[props.Length];
    }
    //private void Start()
    //{
    //    foreach (Image propsImage in props)
    //    {
    //        OnBackpackProps onBackpackProps = propsImage.gameObject.GetComponent<OnBackpackProps>();
    //        onBackpackProps.onClickDown.AddListener(delegate { inventoryEquipment.OnTakeEquipmentButton(); });
    //    }
    //}
    public void AllUpdateRole()
    {
        foreach (var _props in props)
        {
        }
        hpText.text = playerInfo.Energy.ToString();
        attackText.text = playerInfo.Damage.ToString();
        expImage.fillAmount = playerInfo.Exp / 100f;
        expText.text = playerInfo.Exp + "/100";
    }

    public void OnUpdateProps(Equipment equipment, OnBackpackProps onTemporaryOnBackpackProps)//更新到穿戴栏视图
    {
        int intProps = (int)equipment.equipmentInformation.EquipType;
        Sprite sprite = Resources.Load<Sprite>("Image/mainmenu/" + equipment.equipmentInformation.IconString);

        Image imageProps = props[intProps];

        if (onTemporaryOnBackpackProps.Equipment == null)
        {
            //imageProps.GetComponent<Button>().interactable = true; 
        }

        imageProps.sprite = sprite;
        onTemporaryOnBackpackProps.Equipment = equipment;
    }
}
