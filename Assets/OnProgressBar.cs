using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnProgressBar : MonoBehaviour
{
    private Image mImgae;
    private AsyncOperation async;
    private int iTime;
    private Text mText;

    //public string mString;
    // Start is called before the first frame update
    void Start()
    {
        mImgae = transform.Find("proger").GetComponent<Image>();
        mText = transform.gameObject.GetComponentInChildren<Text>();
        //StartCoroutine(Loadscene(mString));//加载场景（场景名）
    }

    public void LoadsceneI(string s)
    {
        StartCoroutine(Loadscene(s));
    }

    public IEnumerator Loadscene(string s)
    {
        //Application.LoadLevelAsync("");
        async = SceneManager.LoadSceneAsync(s);
        async.allowSceneActivation = false;
        yield return async;
        //Debug.Log("666");
    }

    // Update is called once per frame
    void Update()
    {
        if (async == null)
        {
            return;
        }

        int iStep = 0;

        if (async.priority < 0.9f)
        {
            iStep = (int)async.priority * 100;
        }
        else
        {
            iStep = 100;
        }

        if (iTime < iStep)
        {
            iTime++;
        }

        mText.text = iTime + "%";
        mImgae.fillAmount = iTime / 100f;
        if (iTime == 100)
        {
            async.allowSceneActivation = true;
        }
    }
}
