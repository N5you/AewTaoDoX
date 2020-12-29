using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [Header("物品属性")] public EquipmentInformation equipmentInformation;

    private int number = 0; //数量

    private int beEquipmentPosition;//被装备位

    #region 访问权限
    public int NumberInt
    {
        get { return number; }
        set { number = value; }
    }

    #endregion
    //private void Start()
    //{
    //    int i = (int)EquipType.helmet;
    //    Debug.Log(i);
    //}
}