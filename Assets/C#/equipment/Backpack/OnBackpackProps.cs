using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnBackpackProps : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public OnClickDown onClickDown;

    private Equipment equipment = null;
    
    private bool isDown = false;    // 按钮是否是按下状态  
    
    #region 访问权限
    public Equipment Equipment
    {
        get { return equipment; }
        set { equipment = value; }
    }
    #endregion
    public void OnPointerDown(PointerEventData eventData)//按下
    {
        isDown = !false;
        onClickDown.Invoke(equipment);
        //Debug.Log(equipment.equipmentInformation.NameString);
    }

    public void OnPointerUp(PointerEventData eventData)//抬起
    {
        isDown = false;
    }

}
[Serializable]
public class OnClickDown : UnityEvent<Equipment> { }