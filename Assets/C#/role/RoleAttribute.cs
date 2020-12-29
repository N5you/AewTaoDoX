using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAttribute : MonoBehaviour
{
    #region 玩家角色属性
    private string headString; //头像
    private int levelInr; //等级
    private string nameString; //名字
    private int powerInt; //战斗力
    private int expInt; //经验值
    private int diamondInt; //钻石
    private int coinLabel; //金币

    private int hpInt; //生命值【当前生命值/最大生命值】
    private int hpMaxInt; 
    private int mpInt; //魔法值【当前魔法值/最大魔法值】
    private int mpMaxInt;

    private int critFloat;//暴击率
    private float throughFloat;//穿透力
    private int luckyInt;//幸运值
    private int defenseInt; //防御力
    private float rateFloat; //攻速值
    private float speedFloat; //移速值

    private float damgageFloat; //暴击效果
    private int effectInt; //虚拟伤害

    private int strengthInt; //力量
    private int agileInt; //敏捷
    private int intelligenceInt; //智力
    //private void Start()
    //{
    //    OnAllRefresh();
    //}
    public void OnAllRefresh()
    {

    }

    public int GetIntelligence()
    {
        return intelligenceInt;
    }
    public int GetAgile()
    {
        return agileInt;
    }

    public int GetStrength()
    {
        return strengthInt;
    }
    public int GetEffect()
    {
        return effectInt;
    }
    public float GetDamgage()
    {
        return damgageFloat;
    }
    public float GetSpeed()
    {
        return speedFloat;
    }
    public float GetRate()
    {
        return rateFloat;
    }
    public int GetDefense()
    {
        return defenseInt;
    }
    public int GetLucky()
    {
        return luckyInt;
    }
    public float GetThrough()
    {
        return throughFloat;
    }
    public int GetCrit()
    {
        return critFloat;
    }
    public string GetMpString()
    {
        return mpInt + "/" + mpMaxInt;
    }
    public string GetHpString()
    {
        return hpInt + "/" + hpMaxInt;
    }
    public int GetCoinLabel()
    {
        return coinLabel;
    }
    public int GetDiamond()
    {
        return diamondInt;
    }
    public int GetExp()
    {
        return expInt;
    }

    public int GetPower()
    {
        return powerInt;
    }

    public string GetName()
    {
        return nameString;
    }

    public int GetLeve()
    {
        return levelInr;
    }

    public string GetHead()
    {
        return headString;
    }
    #endregion 
}