using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{

    [SerializeField]
    private GameObject stageManu;

    [SerializeField]
    //Scene スクリプト取得
    private SceneM gameManager;



    //経過時間カウント
    private float time_KO;
    private float time_Next;
    // Start is called before the first frame update
    void Start()
    {
        //読み込む
        gameManager = GameObject.Find("GameCountManager").GetComponent<SceneM>();
        gameManager = gameManager.GetComponent<SceneM>();
        //経過時間初期化
        time_KO = 0.0f;
        time_Next = 0.0f;

      
        CountStage();
    }

    // Update is called once per frame
    void Update()
    {
        TimeScene();
        TimeNextSecene();
    }


    public void TimeScene()
    {
        if (gameManager.currentStageNum == 21) return;

        //経過時間をカウント
        time_KO += Time.deltaTime;


        //3秒経過で画面移動
        if (time_KO >= 1.0f)
        {

            stageManu.SetActive(true);
        }
    }
    public void TimeNextSecene()
    {
        if (gameManager.currentStageNum == 21)
        {
            //経過時間をカウント
            time_Next += Time.deltaTime;
            if (time_Next >= 4.0f)
            {
                FadeManager.FadeOut("MasterTitle");
                Destroy(GameObject.FindGameObjectWithTag("SceneManager"));
                Destroy(GameObject.FindGameObjectWithTag("StageSound"));

            }
        }
    }
    void CountStage()
    {
        gameManager.currentStageNum += 1;
        Debug.Log(gameManager.currentStageNum);
    }
}
