//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
public class InventoryEquipment : MonoBehaviour
{
    private TextAsset inventoryTxt;
    private Image[] props;
    //private EquipmentInformation[] equipmentInformation;
    private Dictionary<int, EquipmentInformation> equipmentInformationDictionary = new Dictionary<int, EquipmentInformation>(); //存储物品类型信息
    private List<Equipment> equipmentPlayerInfoDictionary = new List<Equipment>(); //玩家背包

    private Image itemsImage;
    private Image equipmentBgImage;

    private Text priceText;

    public Sprite sprite;

    public Text backpackText;

    private Equipment temporaryInventoryEquipment;
    private GameObject temporaryGameObject;

    private EquipmentBgImage equipmentBgImageScript;
    private OnBackpackItemsImage onBackpackItemsImage;

    private RoleImage roleImage;

    #region 访问权限
    public Dictionary<int, EquipmentInformation> EquipmentInformationDictionary
    {
        get { return equipmentInformationDictionary; }
        set { equipmentInformationDictionary = value; }
    }
    public List<Equipment> EquipmentPlayerInfoDictionary
    {
        get { return equipmentPlayerInfoDictionary; }
        set { equipmentPlayerInfoDictionary = value; }
    }
    #endregion

    private void Awake()
    {
        inventoryTxt = Resources.Load<TextAsset>("Inventory");
        props = transform.Find("BackpackImage/Props").GetComponentsInChildren<Image>();
        //foreach (Image propsprops in props)
        //{
        //    propsprops.GetComponent<Button>().onClick.AddListener(OnInventoryEquipmentButton);
        //}
        ReadInventoryInfo();
        ReadInventoryItemInfo();
        OnUpdateBackpackImageProps();

        itemsImage = transform.Find("ItemsImage").GetComponent<Image>();
        equipmentBgImage = transform.Find("EquipmentBgImage").GetComponent<Image>();

        //backpackText = transform.Find("BackpackImage").Find("Text").GetComponent<Text>();
        equipmentBgImageScript = transform.Find("EquipmentBgImage").GetComponent<EquipmentBgImage>();
        onBackpackItemsImage = itemsImage.gameObject.GetComponent<OnBackpackItemsImage>();

        itemsImage.gameObject.SetActive(false);
        equipmentBgImage.gameObject.SetActive(false);

        priceText = transform.Find("BackpackImage/Image/Text").GetComponent<Text>();

        foreach (Image propsImage in props) //OnInventoryEquipmentButton
        {
            propsImage.gameObject.GetComponent<OnBackpackProps>().onClickDown.AddListener(delegate { OnInventoryEquipmentButton(propsImage.gameObject); });
        }
        roleImage = transform.Find("RoleImage").GetComponent<RoleImage>();
    }

    /// <summary>
    /// 获取物品类型表
    /// </summary>
    private void ReadInventoryInfo()
    {
        string str = inventoryTxt.ToString();
        string[] itemStrArray = str.Split('\n');
        //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述

        foreach (string item in itemStrArray)
        {
            EquipmentInformation equipmentInformation = NewInvnentory(item);
            equipmentInformationDictionary.Add(equipmentInformation.IdInt, equipmentInformation);
        }

        //EquipmentInformation equipmentInformation = new EquipmentInformation();//[itemStrArray.Length];
        //foreach (string o in itemStrArray)
        //{
        //    string[] proArray = o.Split('|');
        //    equipmentInformation.IdInt = int.Parse(proArray[0]);
        //    equipmentInformation.NameString = proArray[1];
        //    equipmentInformation.IconString = proArray[2];
        //    equipmentInformation.EquipmentType = Equipment(proArray[3]);
        //    equipmentInformation.EquipType = Equip(proArray[4]);
        //    equipmentInformation.PriceInt = int.Parse(proArray[5]);//售价
        //    //星级 品质 伤害 生命 战斗力
        //    if (EquipmentType.equipment == equipmentInformation.EquipmentType)
        //    {
        //        equipmentInformation.StarInt = int.Parse(proArray[6]);
        //        equipmentInformation.QualityInt = int.Parse(proArray[7]);
        //        equipmentInformation.DamageInt = int.Parse(proArray[8]);
        //        equipmentInformation.HpInt = int.Parse(proArray[9]);
        //        equipmentInformation.EffectivenessInt = int.Parse(proArray[10]);
        //    }
        //    //作用类型 作用值 描述
        //    equipmentInformation.InfoType = Inventory(proArray[11]);
        //    equipmentInformation.ApplyValue = int.Parse(proArray[12]);
        //    equipmentInformation.DescribeString = proArray[13];
        //    equipmentInformationDictionary.Add(equipmentInformation.IdInt, equipmentInformation);
        //}
    }

    /// <summary>
    /// 把字符串解析成物品类型
    /// </summary>
    /// <param name="o"></param>
    /// <returns>物品类型</returns>
    private EquipmentInformation NewInvnentory(string o)
    {
        //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
        EquipmentInformation equipmentInformation = new EquipmentInformation();//[itemStrArray.Length];

        string[] proArray = o.Split('|');
        equipmentInformation.IdInt = int.Parse(proArray[0]); //Convert.ToInt32(proArray[0]);
        equipmentInformation.NameString = proArray[1];
        equipmentInformation.IconString = proArray[2];
        equipmentInformation.EquipmentType = Equipment(proArray[3]);
        equipmentInformation.EquipType = Equip(proArray[4]);
        equipmentInformation.PriceInt = int.Parse(proArray[5]);//售价
        //星级 品质 伤害 生命 战斗力
        if (EquipmentType.equipment == equipmentInformation.EquipmentType)
        {
            equipmentInformation.StarInt = int.Parse(proArray[6]);
            equipmentInformation.QualityInt = int.Parse(proArray[7]);
            equipmentInformation.DamageInt = int.Parse(proArray[8]);
            equipmentInformation.HpInt = int.Parse(proArray[9]);
            equipmentInformation.EffectivenessInt = int.Parse(proArray[10]);
        }
        //作用类型 作用值 描述
        equipmentInformation.InfoType = Inventory(proArray[11]);
        equipmentInformation.ApplyValue = int.Parse(proArray[12]);
        equipmentInformation.DescribeString = proArray[13];
        //equipmentInformationDictionary.Add(int.Parse(proArray[0]), equipmentInformation);
        return equipmentInformation;
    }

    /// <summary>
    /// 通过“索引”获取物品类型
    /// </summary>
    /// <param name="id">索引</param>
    /// <returns>物品类型</returns>
    private EquipmentInformation GetEquipmentInformationDictionary(int id)
    {
        EquipmentInformation equipmentInformation = equipmentInformationDictionary[id];
        return equipmentInformation;
    }

    /// <summary>
    /// 物品类型判断
    /// </summary>
    /// <param name="str">类型</param>
    /// <returns>返回物品类型</returns>
    private EquipmentType Equipment(string str)
    {
        EquipmentType equipmentType = EquipmentType.Null;
        switch (str)
        {
            case "Equip":
                equipmentType = EquipmentType.equipment;
                break;
            case "Drug":
                equipmentType = EquipmentType.consumables;
                break;
            case "Box":
                equipmentType = EquipmentType.Box;
                break;
        }
        return equipmentType;
    }

    /// <summary>
    /// 装备类型判断
    /// </summary>
    /// <param name="str">类型</param>
    /// <returns>装备类型</returns>
    private EquipType Equip(string str)
    {
        EquipType equipType = EquipType.Null;
        //Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing
        switch (str)
        {
            case "Helm":
                equipType = EquipType.helmet;
                break;
            case "Cloth":
                equipType = EquipType.clothes;
                break;
            case "Weapon":
                equipType = EquipType.weapons;
                break;
            case "Shoes":
                equipType = EquipType.shoes;
                break;
            case "Necklace":
                equipType = EquipType.necklace;
                break;
            case "Bracelet":
                equipType = EquipType.bracelet;
                break;
            case "Ring":
                equipType = EquipType.ring;
                break;
            case "Wing":
                equipType = EquipType.wings;
                break;
        }
        return equipType;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private InventoryType Inventory(string str)
    {
        InventoryType inventoryType = InventoryType.Null;
        switch (str)
        {
            case "Energy":
                inventoryType = InventoryType.Energy;
                break;
        }
        return inventoryType;
    }

    /// <summary>
    /// 读取物品栏的全部物品
    /// </summary>
    private void ReadInventoryItemInfo()
    {
        int str = 1001;//TODO 获取角色所有的物品信息
        int nabo = 1; //获取物品数量
        NewReadInventoryItemInfo(str, nabo);
        //1017
        NewReadInventoryItemInfo(1017, 20);
        NewReadInventoryItemInfo(1012, 1);
        NewReadInventoryItemInfo(1012, 1);
        NewReadInventoryItemInfo(1016, 9);
        NewReadInventoryItemInfo(1011, 1);
    }

    /// <summary>
    /// 创建物品到背包
    /// </summary>
    /// <param name="str">物品ID</param>
    /// <param name="nabo">物品（消耗品）数量，装备为0</param>
    public void NewReadInventoryItemInfo(int str, int nabo)
    {
        Equipment equipment = new Equipment();//创建背包上的物品

        EquipmentInformation equipmentInformation = GetEquipmentInformationDictionary(str);//获取物品类型信息

        equipment.equipmentInformation = equipmentInformation;
        
        //判断是不是消耗品
        if (equipmentInformation.EquipmentType == EquipmentType.consumables) //EquipmentType.consumables  && equipmentInformation.IdInt == equipmentPlayerInfoDictionary[str].equipmentInformation.IdInt
        {
            equipment.NumberInt = nabo;//消耗品数量
            //foreach (Equipment equ in equipmentPlayerInfoDictionary)
            //{
            //    if (str == equ.equipmentInformation.IdInt)
            //    {
            //        equipmentPlayerInfoDictionary[str].Number += 1;//如果存在消耗品就增加数量
            //        return;
            //    }
            //}
            equipmentPlayerInfoDictionary.Add(equipment);//不然就增加物品
        }
        else
        {
            equipmentPlayerInfoDictionary.Add(equipment);//不然就增加物品
        }

        //Debug.Log(equipmentPlayerInfoDictionary[0].equipmentInformation.IdInt);
        //Debug.Log(equipmentPlayerInfoDictionary[0].equipmentInformation.IdInt);
        backpackText.text = equipmentPlayerInfoDictionary.Count + "/20";
    }

    /// <summary>
    /// 更新物品栏视图
    /// </summary>
    public void OnUpdateBackpackImageProps()
    {
        int i = 0;
        foreach (Equipment equipment in equipmentPlayerInfoDictionary)
        {
            if (i <= props.Length)
            {
                string str = equipment.equipmentInformation.IconString;
                Sprite sprite = Resources.Load<Sprite>("Image/mainmenu/" + str);
                Image propsImage = props[i];
                Image imageProps = propsImage.transform.Find("Image").GetComponent<Image>();
                imageProps.sprite = sprite;
                imageProps.gameObject.SetActive(true);
                if (equipment.NumberInt > 0)
                {
                    propsImage.rectTransform.Find("Text").GetComponent<Text>().text = equipment.NumberInt.ToString();
                }
                //imageProps.rectTransform.parent.gameObject.name = equipment.equipmentInformation.IdInt.ToString();
                //imageProps.rectTransform.parent.get
                propsImage.GetComponent<OnBackpackProps>().Equipment = equipment;
            }
            i++;
        }
    }
    /// <summary>
    /// 关闭背包面板
    /// </summary>
    public void OnShutdownButton()
    {
        itemsImage.gameObject.SetActive(false);
        equipmentBgImage.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        priceText.text = "0";
    }

    /// <summary>
    /// 背包物品被点击
    /// </summary>
    public void OnInventoryEquipmentButton(GameObject button)
    {
        //var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        //foreach (Image propsprops in props)
        //{
        //    propsprops.GetComponent<Button>().onClick.AddListener(OnInventoryEquipmentButton);
        //}
        //button.name
        //知道是equipmentPlayerInfoDictionary中的哪件装备

        if (button.transform.Find("Image").gameObject.activeSelf == false) return;

        Equipment equipment = button.GetComponent<OnBackpackProps>().Equipment;

        temporaryInventoryEquipment = equipment;

        temporaryGameObject = button;

        if (equipment.equipmentInformation.EquipmentType == EquipmentType.equipment) //判断是不是装备
        {
            if (itemsImage.gameObject.activeSelf)
            {
                itemsImage.gameObject.SetActive(false);
            }
            equipmentBgImage.gameObject.SetActive(true);
            equipmentBgImageScript.OnUpdateEquipmentBgImage(equipment);//获取信息并设置（装备）
            priceText.text = equipment.equipmentInformation.PriceInt.ToString(); //价格设置
            //equipmentBgImageScript.TemporaryInventoryEquipment = equipment;
            equipmentBgImageScript.TemporaryInventoryEquipment = equipment;
        }
        else
        {
            //获取信息并设置（消耗品）
            itemsImage.gameObject.SetActive(true);
            if (equipmentBgImage.gameObject.activeSelf)
            {
                equipmentBgImage.gameObject.SetActive(false);
            }
            int iPrice = equipment.equipmentInformation.PriceInt * equipment.NumberInt;
            priceText.text = iPrice.ToString(); ; //价格设置：价格*数量
            onBackpackItemsImage.OnUpdateEquipmentBgImage(equipment);
        }
    }

    /// <summary>
    /// 出售背包物品
    /// </summary>
    public void OnSellInventoryEquipment()
    {
    }

    /// <summary>
    /// 整理按钮，实际上是：重置这个背包全部图标
    /// </summary>
    public void OnFinishingInventoryButoon()
    {
        foreach (Image propsImage in props)
        {
            Image imagePropsReset = propsImage.transform.Find("Image").GetComponent<Image>();
            imagePropsReset.sprite = null;
            imagePropsReset.gameObject.SetActive(false);
            propsImage.rectTransform.Find("Text").GetComponent<Text>().text = "";
        }
        OnUpdateBackpackImageProps();
    }

    /// <summary>
    /// 穿戴装备
    /// </summary>
    public void OnWearEquipmentButton()
    {
        OnBackpackProps onTemporaryOnBackpackProps = temporaryGameObject.GetComponent<OnBackpackProps>();

        int iInt = (int)onTemporaryOnBackpackProps.Equipment.equipmentInformation.EquipType;

        if (onTemporaryOnBackpackProps != null)
        {
            onTemporaryOnBackpackProps.Equipment = null;//置空背包
        }

        OnBackpackProps onBackpackPropsTemporary = roleImage.Props[iInt].GetComponent<OnBackpackProps>();//获取装备栏的OnBackpackProps属性
        onBackpackPropsTemporary.Equipment = temporaryInventoryEquipment;//设置装备栏的OnBackpackProps属性

        if (onBackpackPropsTemporary.Equipment != null)//装备替换
        {
            UpdateIconPropsImage(onTemporaryOnBackpackProps.Equipment, 0);//更新图标
            if (!equipmentPlayerInfoDictionary.Contains(onTemporaryOnBackpackProps.Equipment)) equipmentPlayerInfoDictionary.Add(onTemporaryOnBackpackProps.Equipment);//添加到集合
        }

        roleImage.OnUpdateProps(temporaryInventoryEquipment, onTemporaryOnBackpackProps);//更新到穿戴栏视图

        equipmentBgImageScript.OnShutdownButton();//关闭详细信息面板
        equipmentPlayerInfoDictionary.Remove(temporaryInventoryEquipment); //删除背包集合中的物品

        //在视图中，删除背包中物品
        temporaryGameObject.transform.Find("Image").gameObject.SetActive(false);

        Debug.Log(equipmentPlayerInfoDictionary.Count);
    }

    /// <summary>
    /// 脱下装备
    /// </summary>
    public void OnTakeEquipmentButton()//参数即被点击装备
    {
    }
    public void OnTakeEquipmentButton(int buttonInt)//参数即被点击装备
    {

        //置空装备栏的装备
        OnBackpackProps onBackpackPropsTemporary = roleImage.Props[buttonInt].GetComponent<OnBackpackProps>();//获取装备栏的OnBackpackProps属性

        //Equipment buttonEquipment = roleImage.PropsEquipment[buttonInt];//获取脱下装备
        Equipment buttonEquipment = onBackpackPropsTemporary.Equipment;

        //if (buttonEquipment == null) return;
        if (roleImage.Props[buttonInt].sprite == sprite) return;

        //增加脱下装备到背包 equipmentPlayerInfoDictionary
        if(!equipmentPlayerInfoDictionary.Contains(buttonEquipment)) equipmentPlayerInfoDictionary.Add(buttonEquipment);

        //装备栏更新
        //roleImage.PropsEquipment[buttonInt] = null;
        roleImage.Props[buttonInt].sprite = sprite;

        onBackpackPropsTemporary.Equipment = null;//置空装备栏的装备

        //更新背包栏面板
        NewEquipmentBackpack(buttonEquipment, 0);
    }

    /// <summary>
    /// 把物品放进背包
    /// </summary>
    /// <param name="equipment">物品</param>
    /// <param name="nabo">数量</param>
    public void NewEquipmentBackpack(Equipment equipment, int nabo)
    {
        if (equipment.equipmentInformation.EquipmentType == EquipmentType.consumables)//判断是不是消耗品
        {
            equipment.NumberInt = nabo;//设置消耗品数量
            equipmentPlayerInfoDictionary.Add(equipment);//不然就增加物品
        }
        else
        {
            equipmentPlayerInfoDictionary.Add(equipment);//不然就增加物品，//添加到背包
        }

        backpackText.text = equipmentPlayerInfoDictionary.Count + "/20"; //背包容量Text显示

        //更新背包图标
        UpdateIconPropsImage(equipment, nabo);

        Debug.Log(equipmentPlayerInfoDictionary.Count);
    }

    /// <summary>
    /// 更新背包图标
    /// </summary>
    /// <param name="equipment">物品</param>
    /// <param name="nabo">数量</param>
    public void UpdateIconPropsImage(Equipment equipment, int nabo)
    {
        foreach (Image propsImage in props)
        {
            Image imagePropsReset = propsImage.transform.Find("Image").GetComponent<Image>();
            if (imagePropsReset.gameObject.activeSelf == false)
            {
                string str = equipment.equipmentInformation.IconString;//获取图标
                Sprite sprite = Resources.Load<Sprite>("Image/mainmenu/" + str);
                imagePropsReset.sprite = sprite;
                imagePropsReset.gameObject.SetActive(true);

                if (nabo != 0) propsImage.transform.Find("Text").GetComponent<Text>().text = nabo.ToString();//设置数量显示

                propsImage.GetComponent<OnBackpackProps>().Equipment = equipment;//

                return;
            }
        }
    }

    //删除背包中指定物品
}