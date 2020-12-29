using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoServer : MonoBehaviour
{
    //1、存储值：本地化存储方式，一般用在保存玩家的偏好设置中，常见于玩家设置，记住密码，音乐音效值 分数存取
    //PlayerPrefs.SetFloat(string key, float value); //通过key 与value 存储，就像键值对一样。
　　//PlayerPrefs.SetInt(string key, Int value);
　　//PlayerPrefs.SetString(string key, string value);

    //2、读取值：
　　//PlayerPrefs.GetFloat(string key);  //通过key得到存储的value值
　　//PlayerPrefs.GetInt(string key);
　　//PlayerPrefs.GetString(string key);
    private string _key;
    void intt()
    {
        PlayerPrefs.GetFloat(_key + "Coun");
        PlayerPrefs.GetFloat(_key + "Diamond");
        PlayerPrefs.GetFloat(_key + "Exp");
        PlayerPrefs.GetFloat(_key + "HeadPortrait");
        PlayerPrefs.GetFloat(_key + "Level");
        PlayerPrefs.GetFloat(_key + "Name");
        PlayerPrefs.GetFloat(_key + "Power");
        PlayerPrefs.GetFloat(_key + "Toughen");
    }
}
