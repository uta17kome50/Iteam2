using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject Button1;
    [SerializeField]
    private GameObject Button2;
    [SerializeField]
    private GameObject Button3;

    [SerializeField]
    //Scene スクリプト取得
    private SceneM gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //読み込む
        gameManager = GameObject.Find("GameCountManager").GetComponent<SceneM>();
        gameManager = gameManager.GetComponent<SceneM>();
    }
    void OnEnable()
    {
        // 自分を選択状態にする
        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //名前を取得して分岐
        switch (transform.name)
        {
            case "End":
                End();
                break;
            case "Title":
                TitleButton();
                break;
            case "ReStart":
                Restart();
                break;
            default:
                break;

        }

    }
    public void End()
    {
        Debug.Log("終了");
        Application.Quit();
        //Quit();

        Button1.gameObject.SetActive(false);

        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);
    }

    public void TitleButton()
    {

        FadeManager.FadeOut("Title");
        Destroy(GameObject.FindGameObjectWithTag("SceneManager"));
        Destroy(GameObject.FindGameObjectWithTag("StageSound"));
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);

    }

    public void Restart()
    {
        if (gameManager.currentStageNum == 21)
        {
            FadeManager.FadeOut("Title");
        }
        else
        {
            FadeManager.FadeOut("stage" + gameManager.currentStageNum);

        }
        Destroy(GameObject.FindGameObjectWithTag("SceneManager"));
        Destroy(GameObject.FindGameObjectWithTag("StageSound"));
        Button1.gameObject.SetActive(false);

        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);

    }
}
