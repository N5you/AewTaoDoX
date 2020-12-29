using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Sprites;
public enum InfoType
{
    head,
    level,
    name,
    power,
    exp,
    diamond,
    coin,

    hp,
    mp,

    crit,
    through,
    lucky,
    defense,
    rate,
    speed,

    damgage,
    effect,

    Power,
    Agile,
    Brains,

    all
}
public class PlayerInfo : MonoBehaviour
{
    private float energyTimer = 0;
    private float toughenTimer = 0;

    #region 人物信息
    private string _name; //名字
    private string _headPortralt; //头像
    private int _level; //等级
    private int _power; //战斗力
    private int _damage; //攻击力
    private int _exp; //经验值
    private int _diamond;//钻石
    private int _coin;//金币
    private int _energy;//生命值
    private int _toughen;//魔法值
    #endregion

    public static PlayerInfo playerInfonstance;

    public delegate void OnPlayerInfoChangedEvent(InfoType type);

    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;

    #region 信息访问控制
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string HeadPortralt
    {
        get
        {
            return _headPortralt;
        }
        set
        {
            _headPortralt = value;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;
        }
    }
    public int Diamond
    {
        get
        {
            return _diamond;
        }
        set
        {
            _diamond = value;
        }
    }
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
    public int Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }
    public int Toughen
    {
        get
        {
            return _toughen;
        }
        set
        {
            _toughen = value;
        }
    }
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    private void Init()
    {
        _name = "飞将"; //名字
        _headPortralt = "UI-Taodo/002-mainmenu/HeadImage001"; //头像
        _level = 4; //等级
        //_power = 100; //战斗力
        _exp = 0; //经验值
        _diamond = 9542;//钻石
        _coin = 1852;//金币
        //_energy = 100;//生命值
        _toughen = 100;//魔法值
        //OnPlayerInfoChanged(InfoType.all);
        _energy = _level * 100;
        _damage = _level * 50;
        _power = _energy + _damage;
    }

    #endregion

    #region Unity event
    private void Awake()
    {
        playerInfonstance = this;
        if(playerInfonstance == null)
        {
            playerInfonstance = GetComponent<PlayerInfo>();
        }
        if (playerInfonstance == null)
        {
            playerInfonstance = new PlayerInfo();
        }
    }

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        if (this.Energy < 100)//每分钟恢复生命值
        {
            energyTimer += Time.deltaTime;
            if (energyTimer>60)
            {
                Energy += 1;
                energyTimer = 0;
                OnPlayerInfoChanged(InfoType.hp);
            }
        }

        if (this.Toughen < 100)//每分钟恢复魔法值
        {
            toughenTimer += Time.deltaTime;
            if(toughenTimer > 60)
            {
                Toughen += 1;
                toughenTimer = 0;
                OnPlayerInfoChanged(InfoType.mp);
            }
        }
    }
    #endregion
}