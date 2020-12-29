using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerProperty : MonoBehaviour
{
    private string ip;
    private string name;
    private int count;

    public bool isPress;

    private StartMenuCollo startMenuCollo;
    private void Start()
    {
        startMenuCollo = GameObject.Find("Canvas").GetComponent<StartMenuCollo>();
    }
    public string GetIp()
    {
        return ip;
    }

    public void SetIp(string s)
    {
        ip = s;
    }
    public int GetCount()
    {
        return count;
    }

    public void SetCount(int s)
    {
        count = s;
    }
    public string GetName()
    {
        return name;
    }

    public void SetName(string s)
    {
        name = s;
    }

    public void OnPress()//bool isPress
    {
        //if (isPress == false)
        //{
        //transform.root.SendMessage("HidePanel", gameObject);
        //选择了当前的服务器
        //}
        if (isPress == false)
        {
            startMenuCollo.OnServerselect(gameObject);
            isPress = true;
        }
        else
        {
            startMenuCollo.OnServerselectedClose();
        }
    }
}