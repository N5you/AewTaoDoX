using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuCollo : MonoBehaviour
{
    //public static StreamingController _instance;
    public Image imageBgLogo; //开始面板/进入游戏面板
    public Image imageBgLogin; //登陆面板
    public Image imageRegistered; //注册面板
    public Image imageServer; //服务器面板
    public Image imageGoGame;
    public GameObject imageGameObj; //更换角色面板

    public Text usernameLabelStart;
    public Text servernameLabelStart;

    public InputField usernameInputField;
    public InputField passwordInputField;

    public InputField inpAccount;
    public InputField inpPassword;

    private static string username;
    private static string password;
    private bool haveInitServerlist;
    //private ServerProperty sp;
    private GameObject serverSelectedGo;

    public GameObject listServerInit;
    public GameObject hotServer;
    public GameObject smoothServer;

    public GameObject[] characterArray;
    public GameObject[] CharcterSelectedArray;
    public Transform characterSelectedParent;
    public Text nameLabelCharacterselect;
    public Text lvLabelCharacterselect;
    private void Awake()
    {
        //_instance = this;
    }
    private void Start()
    {
        //初始化服务器列表
        InitServerkust();
    }

    public void OnButtonChangechracterClick()//点击了更换角色按钮
    {
        imageGoGame.gameObject.SetActive(false);
        imageGameObj.SetActive(true);
    }

    private GameObject characterSelected;
    private int iCharacterSelected = -1;
    public void OnCharactershowButtonSureClick() //确定更换选择角色
    {
        //判断姓名输入是否正确 TODO
        //foreach (var Array in characterArray)
        //{
        //    if (characterSelected == Array)
        //    {
        //    }
        //}
        for (int i =0;i < characterArray.Length;i++)
        {
            Debug.Log(characterArray[i].name);
            if (characterSelected.name == characterArray[i].name)
            {
                iCharacterSelected = i;
                break;
                
            }
        }

        if (iCharacterSelected != -1)
        {
            GameObject.Destroy(characterSelectedParent.GetComponentInChildren<Animation>().gameObject);
            GameObject go = GameObject.Instantiate(CharcterSelectedArray[iCharacterSelected], Vector3.zero, Quaternion.identity);
            go.transform.parent = characterSelectedParent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = new Vector3(1f,1f,1f);
            nameLabelCharacterselect.text = imageGameObj.transform.Find("InputField-name").GetComponent<InputField>().text;
            lvLabelCharacterselect.text = "Lv：0";
            OnLoginCloseClick("进入游戏");
        }
        Debug.Log(iCharacterSelected);
        Debug.Log(characterSelected);
    }
    public void OnCharacterClick(GameObject go)
    {
        iTween.ScaleTo(go.transform.parent.gameObject,new Vector3(1.5f,1.5f,1.5f),0.5f);
        if (characterSelected != null && characterSelected != go)
        {
            iTween.ScaleTo(characterSelected.transform.parent.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
        }
        characterSelected = go;
    }

    public void OnServerClick() //选择服务器 TODO
    {
        imageRegistered.gameObject.SetActive(false);
        imageBgLogo.transform.gameObject.SetActive(false);
        imageBgLogin.transform.gameObject.SetActive(false);
        imageServer.transform.gameObject.SetActive(true);
    }

    public void InitServerkust()
    {
        if (haveInitServerlist) return;
        haveInitServerlist = true;
        //连接服务器，取得服务器列表信息TODO
        //根据上面的信息，添加服务器列表
        int serverInt = 10;
        for(int i = 0; i < serverInt; i++)
        {
            string ip = "";//获取服务器ip
            string name = "";//获取服务器名字
            int count = 0;//获取服务器人数
            GameObject newHotServer;
            if (count > 100)//服务器是否火爆
            {
                newHotServer = Instantiate(hotServer, listServerInit.transform);
            }
            else
            {
                newHotServer = Instantiate(smoothServer, listServerInit.transform);
            }
            newHotServer.transform.parent = listServerInit.transform;
            newHotServer.transform.Find("Text").GetComponent<Text>().text = name;
            newHotServer.GetComponent<ServerProperty>().SetName("name");
        }
        //RectTransform listServerInitRectTransform = 
        //int i8 = (serverInt * 45) + (serverInt * 10); //设置列表高度
        //listServerInit.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, i8);
        //listServerInitRectTransform.transform
    }
    public void OnUserNameClick()//登陆面板
    {
        if (username != null)
        {
            usernameInputField.text = username;
        }

        if (password != null)
        {
            passwordInputField.text = password;
        }

        usernameLabelStart.text = username;
        //切换登陆面板
        imageRegistered.transform.gameObject.SetActive(false);
        imageBgLogo.transform.gameObject.SetActive(false);
        imageBgLogin.transform.gameObject.SetActive(true);
    }

    public void OnEnterGameClick()//进入游戏
    {
        //连接服务器，验证用户名密码和服务器 TODO
        imageRegistered.transform.gameObject.SetActive(false);
        imageBgLogo.transform.gameObject.SetActive(false);
        imageBgLogin.transform.gameObject.SetActive(false);
        imageServer.transform.gameObject.SetActive(false);
        imageGoGame.transform.gameObject.SetActive(true);
        //进入角色选择界面
    }

    public void OnLoginClick()//登陆入游戏
    {
        username = usernameInputField.text;
        password = passwordInputField.text;
        //验证用户名和密码 TODO
        //返回开始界面
        imageBgLogo.transform.gameObject.SetActive(true);
        imageBgLogin.transform.gameObject.SetActive(false);
        imageRegistered.transform.gameObject.SetActive(false);
    }

    public void OnRegisterSgiwClick() //注册面板
    {
        imageBgLogo.transform.gameObject.SetActive(false);
        imageBgLogin.transform.gameObject.SetActive(false);
        imageRegistered.transform.gameObject.SetActive(true);
    }

    public void OnRegisterAndLandingClick() //注册并登陆
    {
        //本地验证，连接服务器进行验证 TODO

        //保存用户名密码
        username = inpAccount.text;
        password = inpPassword.text;

        OnLoginClick(); //直接使用登陆方法，登陆方法会使用账户密码验证，所以上面的服务器验证可以少这一步
    }

    /// <summary>
    /// 关闭功能通用
    /// </summary>
    /// <param name="s">参数“开始”返回开始面板</param>
    public void OnLoginCloseClick(string s)//关闭按钮
    {
        //if (imageBgLogo.transform.gameObject.activeInHierarchy == true)
        //{
        //}
        //imageBgLogo.transform.gameObject.SetActive(true);
        //imageBgLogin.transform.gameObject.SetActive(false);
        //imageRegistered.transform.gameObject.SetActive(false);
        if (s == "开始")
        {
            imageRegistered.transform.gameObject.SetActive(false);
            imageBgLogin.transform.gameObject.SetActive(false);
            imageServer.transform.gameObject.SetActive(false);
            imageBgLogo.transform.gameObject.SetActive(true);
        }
        else if (s == "进入游戏")
        {
            iCharacterSelected = -1;
            imageGameObj.SetActive(false);
            imageGoGame.gameObject.SetActive(true);  
        }
    }

    public void OnRegisterCancelClick() //注册页面的取消
    {
        OnUserNameClick();
    }

    /// <summary>
    /// 被选择服务器替换
    /// </summary>
    /// <param name="serverGo">选中的服务器，被替换上去的服务器</param>
    public void OnServerselect(GameObject serverGo)
    {
        //sp = serverGo.GetComponent<ServerProperty>();
        //serverSelectedGo.GetComponent<Button>
        GameObject go;
        if (serverSelectedGo != null)
        {
            go = serverSelectedGo;
            go.transform.parent = listServerInit.transform;//替换下去
            go.GetComponent<RectTransform>().position = serverGo.GetComponent<RectTransform>().position;
            go.GetComponent<ServerProperty>().isPress = false;
        }
        serverSelectedGo = serverGo;//替换上去
        serverGo.transform.parent = imageServer.gameObject.transform;
        //serverGo.transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        //serverGo.transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        //serverGo.GetComponent<RectTransform>().offsetMin = new Vector2(GetComponent<RectTransform>().offsetMin.x, GetComponent<RectTransform>().offsetMin.y);
        serverGo.GetComponent<RectTransform>().position = new Vector3(476.9f, 402f, 0f);//(0f, 125f, 0f);
    }

    public void OnServerselectedClose()
    {
        //隐藏服务器列表
        OnLoginCloseClick("开始");
        //显示开始界面，并修改名字
        servernameLabelStart.text = serverSelectedGo.transform.Find("Text").GetComponent<Text>().text;//serverSelectedGo
    }

    IEnumerator HidePanel(GameObject go) //协程，等动画播放完隐藏面板
    {
        yield return new WaitForSeconds(0.4f);
        go.SetActive(false);
    }
}