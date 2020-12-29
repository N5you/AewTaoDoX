using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品类型
/// </summary>
public enum EquipmentType
{
    consumables,//消耗品
    equipment, //装备
    Box,
    Null
}

/// <summary>
/// 装备类型
/// </summary>
public enum EquipType
{
    helmet = 0, //头盔
    clothes = 1, //衣服
    weapons = 2, //武器
    shoes = 3, //鞋子
    necklace = 4, //项链
    bracelet = 5, //手镯
    ring = 6, //戒指
    wings = 7, //翅膀
    Null
}

/// <summary>
/// z作用类型
/// </summary>
public enum InventoryType
{
    Energy,
    Null
}

[System.Serializable]
public class EquipmentInformation: MonoBehaviour
{
    [SerializeField] private int idInt; //ID
    [SerializeField] private string nameString; //名称
    [SerializeField] private string iconString; //图标
    [SerializeField] private EquipmentType equipmentType; //类型
    [SerializeField] private EquipType equipType; //装备类型
    [SerializeField] private int levelInt; //等级
    [SerializeField] private int numberInt;//个数
    [SerializeField] private int priceInt;//售价
    [SerializeField] private int starInt;//星级
    [SerializeField] private int qualityInt; //品质
    [SerializeField] private int damageInt; //伤害
    [SerializeField] private int hpInt;//生命
    [SerializeField] private int effectivenessInt;//战斗力
    [SerializeField] private InventoryType roleType;//作用类型
    [SerializeField] private int applyValue;//作用值
    [SerializeField] private string describeString; //描述

    public int IdInt
    {
        get { return idInt; }
        set { idInt = value; }
    }
    public string NameString
    {
        get { return nameString; }
        set { nameString = value; }
    }
    public string IconString
    {
        get { return iconString; }
        set { iconString = value; }
    }
    public EquipmentType EquipmentType
    {
        get { return equipmentType; }
        set { equipmentType = value; }
    }
    public EquipType EquipType
    {
        get { return equipType; }
        set { equipType = value; }
    }
    public int LevelInt
    {
        get { return levelInt; }
        set { levelInt = value; }
    }
    public int NumberInt
    {
        get { return numberInt; }
        set { numberInt = value; }
    }
    public int PriceInt
    {
        get { return priceInt; }
        set { priceInt = value; }
    }
    public int StarInt
    {
        get { return starInt; }
        set { starInt = value; }
    }
    public int QualityInt
    {
        get { return qualityInt; }
        set { qualityInt = value; }
    }
    public int DamageInt
    {
        get { return damageInt; }
        set { damageInt = value; }
    }
    public int HpInt
    {
        get { return hpInt; }
        set { hpInt = value; }
    }
    public int EffectivenessInt
    {
        get { return effectivenessInt; }
        set { effectivenessInt = value; }
    }
    public InventoryType InfoType
    {
        get { return roleType; }
        set { roleType = value; }
    }
    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }
    public string DescribeString
    {
        get { return describeString; }
        set { describeString = value; }
    }
}