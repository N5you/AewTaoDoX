using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAStatus : MonoBehaviour
{
    [Tooltip("角色属性")]public RoleAttribute roleAttribute;

    private Image headImage; //头像
    private Text levelText; //等级
    private Text nameText; //名字
    private Text powerText; //战斗力
    private Text expText; //经验值
    private Image expImage;
    private Text diamondText; //钻石
    private Text coinLabel; //金币

    private Text hpText; //生命值【当前生命值/最大生命值】
    private Text mpText; //魔法值【当前魔法值/最大魔法值】

    private Text critText;//暴击率
    private Text throughText;//穿透力
    private Text luckyText;//幸运值
    private Text defenseText; //防御力
    private Text rateText; //攻速值
    private Text speedText; //移速值

    private Text damgageText; //暴击效果
    private Text effectText; //虚拟伤害

    private Text attributeAPowerText; //力量
    private Text attributeAAgilleText; //敏捷
    private Text attributeABrains; //智力

    //public delegate void OnPlayerInfoChangedEvent(InfoType type);

    //public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;
    private Image imageRename;
    private void Awake()
    {
        headImage = transform.Find("ImageHead").GetComponent<Image>();
        levelText = transform.Find("TextLv").GetComponent<Text>();
        nameText = transform.Find("TextID").GetComponent<Text>();
        powerText = transform.Find("TextPower/Text").GetComponent<Text>();
        expText = transform.Find("TextExe/Text").GetComponent<Text>();
        expImage = transform.Find("TextExe/ImageExp").GetComponent<Image>();
        diamondText = transform.Find("ImageDiomondBg/Text").GetComponent<Text>();
        coinLabel = transform.Find("ImageCoinBg/Text").GetComponent<Text>();

        hpText = transform.Find("TextHP/Text").GetComponent<Text>();
        mpText = transform.Find("TextMP/Text").GetComponent<Text>();

        critText = transform.Find("TextCrit/Text").GetComponent<Text>();
        throughText = transform.Find("TextThrough/Text").GetComponent<Text>();
        luckyText = transform.Find("TextLucky/Text").GetComponent<Text>();
        defenseText = transform.Find("TextDefense/Text").GetComponent<Text>();
        rateText = transform.Find("TextRate/Text").GetComponent<Text>();
        speedText = transform.Find("TextSpeed/Text").GetComponent<Text>();

        damgageText = transform.Find("ImageAttributeA/TextDamage/Text").GetComponent<Text>();
        effectText = transform.Find("ImageAttributeA/TextEffect/Text").GetComponent<Text>();

        attributeAPowerText = transform.Find("ImageAttributeB/TextPower/Text").GetComponent<Text>();
        attributeAAgilleText = transform.Find("ImageAttributeB/TextAgile/Text").GetComponent<Text>();
        attributeABrains = transform.Find("ImageAttributeB/TextBrains/Text").GetComponent<Text>();

        imageRename = transform.Find("ImageRename").GetComponent<Image>();
    }
    /// <summary>
    /// 全部属性显示更新
    /// </summary>
    public void OnAllRefresh()
    {
        headImage.sprite = Resources.Load(roleAttribute.GetHead(), typeof(Sprite)) as Sprite;
        levelText.text = roleAttribute.GetLeve().ToString();
        nameText.text = roleAttribute.GetName();
        powerText.text = roleAttribute.GetPower().ToString();
        expText.text = roleAttribute.GetExp() + "%";
        expImage.fillAmount = roleAttribute.GetExp() / 100f;
        diamondText.text = roleAttribute.GetDiamond().ToString();//System.Convert.ToInt32(roleAttribute.GetDiamond() * 100f) + "%";
        coinLabel.text = roleAttribute.GetCoinLabel().ToString();
        hpText.text = roleAttribute.GetHpString();
        mpText.text = roleAttribute.GetMpString();
        critText.text = roleAttribute.GetCrit().ToString();
        throughText.text = System.Convert.ToInt32(roleAttribute.GetThrough() * 100).ToString();
        luckyText.text = roleAttribute.GetLucky().ToString();
        defenseText.text = roleAttribute.GetDefense().ToString();
        rateText.text = System.Convert.ToInt32(roleAttribute.GetRate()).ToString();
        speedText.text = System.Convert.ToInt32(roleAttribute.GetSpeed()).ToString();
        damgageText.text = System.Convert.ToInt32(roleAttribute.GetDamgage() * 100).ToString();
        effectText.text = roleAttribute.GetEffect().ToString();
        attributeAPowerText.text = roleAttribute.GetStrength().ToString();
        attributeAAgilleText.text = roleAttribute.GetAgile().ToString();
        attributeABrains.text = roleAttribute.GetIntelligence().ToString();
    }
    public void OnButtonShuDown()//关闭
    {
        gameObject.SetActive(false);
    }
    public void OnButtonOpenThe()//打开
    {
        gameObject.SetActive(true);
        OnAllRefresh();
    }

    private void OnNemeText(string name)
    {
        transform.parent.Find("Playerbar").GetComponent<PlayerBay>().OnNameText(name);
        nameText.text = name;
        // TODO 存储名字
    }

    public void OnButtonCancelName() //关闭改名
    {
        imageRename.gameObject.SetActive(false);
    }

    public void OnButtonDetermineName() //确定改名
    {
        string name = imageRename.transform.Find("InputField").GetComponent<InputField>().text;//InputField
        if (name != "" && name != nameText.text)
        {
            OnNemeText(name);
            imageRename.gameObject.SetActive(false);
        }
    }

    public void OnButtonImageRename()//打开改名
    {
        imageRename.gameObject.SetActive(true);
    }
}