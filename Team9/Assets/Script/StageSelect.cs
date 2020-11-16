using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    int cntMove;
    int cntnumber;
    int cntStage = 1;

    int stageMax = 20;//最大ステージ数
    int stageMin = 1;//最小ステージ数

    private bool rightMoveFlag;
    private bool leftMoveFlag;
    private bool endFlag;

    public Animator targetAnimator;
    public Animator targetAnimatorLeft;
    public Animator effect;

    // Start is called before the first frame update
    void Start()
    {
        stageMax = 20;
        stageMin = 1;

        FadeManager.FadeIn();

        cntnumber = 0;
        cntMove = 0;
        rightMoveFlag = false;
        leftMoveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (endFlag == true)
        {
            StartCoroutine("Flag");
        }
        if (endFlag == true)
        {
            return;
        }

            //Transform myTransform = this.transform;
            //Vector3 pos = myTransform.position;
            transform.localPosition = new Vector3(cntMove, 0, 0);
            // 座標を取得
            //pos= myTransform.localPosition;
            //pos.x = 400;

            if (rightMoveFlag == true)
            {
                cntMove -= 10;
                cntnumber += 10;
                if (cntnumber == 400)
                {
                    rightMoveFlag = false;
                    cntnumber = 0;
                }
            }

            if (leftMoveFlag == true)
            {
                cntMove += 10;
                cntnumber += 10;
                if (cntnumber == 400)
                {
                    leftMoveFlag = false;
                    cntnumber = 0;
                }
            }

            //myTransform.position =pos;
            Select();
            if (cntStage != stageMax && Input.GetAxis("Horizontal") > 0.8f && rightMoveFlag == false && leftMoveFlag == false)
            {
                targetAnimator.SetTrigger("Right");
            
                if (cntStage == stageMin)
                {
                    targetAnimatorLeft.SetTrigger("Lightsup");
                }
                cntStage++;
                rightMoveFlag = true;
                if (cntStage == stageMax)
                {
                    targetAnimator.SetTrigger("Invisible");
                }
            }

            if (cntStage != stageMin && Input.GetAxis("Horizontal") < -0.8f && rightMoveFlag == false && leftMoveFlag == false)
            {
                targetAnimatorLeft.SetTrigger("Right");
             
                if (cntStage == stageMax)
                {
                    targetAnimator.SetTrigger("Lightsup");
                }
                cntStage--;

                leftMoveFlag = true;
                if (cntStage == stageMin)
                {
                    targetAnimatorLeft.SetTrigger("Invisible");
                }
            }
            if (cntStage == stageMax && Input.GetAxis("Horizontal") > 0.1f && rightMoveFlag == false && leftMoveFlag == false)
            {
                //cancel.clip = cancel1;
                //cancel.Play();
            }
            if (cntStage == stageMin && Input.GetAxis("Horizontal") < -0.1f && rightMoveFlag == false && leftMoveFlag == false)
            {
                //cancel.clip = cancel1;
                //cancel.Play();
            }




         

        }
    
    void Select()
    {
        if (Input.GetKeyDown("joystick button 0") && rightMoveFlag == false && leftMoveFlag == false)
        {
            if (cntStage == 1 || cntStage == 2 || cntStage == 3 || cntStage == 4 || cntStage == 5 || cntStage == 6 || cntStage == 7 || cntStage == 8 || cntStage == 9 || cntStage == 10
                || cntStage == 11|| cntStage == 12|| cntStage == 13|| cntStage == 14|| cntStage == 15|| cntStage == 16|| cntStage == 17|| cntStage == 18|| cntStage == 19|| cntStage == 20)
            {
              
                    endFlag = true;
                  
                    StartCoroutine("End");
                
            }
            else
            {
              
            }
        }

    }
    public IEnumerator End()
    {
        yield return new WaitForSeconds(1.5f);
        if (cntStage == 1)
        {
            Debug.Log("1");
            FadeManager.FadeOut("Stage1");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 2)
        {
            Debug.Log("2");
            FadeManager.FadeOut("Stage2");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 3)
        {
            Debug.Log("3");
            FadeManager.FadeOut("Stage3");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 4)
        {
            Debug.Log("4");
            FadeManager.FadeOut("Stage4");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 5)
        {
            Debug.Log("5");
            FadeManager.FadeOut("Stage5");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 6)
        {
            Debug.Log("6");
            FadeManager.FadeOut("Stage6");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 7)
        {
            Debug.Log("7");
            FadeManager.FadeOut("Stage7");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 8)
        {
            Debug.Log("8");
            FadeManager.FadeOut("Stage8");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 9)
        {
            Debug.Log("9");
            FadeManager.FadeOut("Stage9");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 10)
        {
            Debug.Log("10");
            FadeManager.FadeOut("Stage10");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 11)
        {
            Debug.Log("11");
            FadeManager.FadeOut("Stage11");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 12)
        {
            Debug.Log("12");
            FadeManager.FadeOut("Stage12");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 13)
        {
            Debug.Log("13");
            FadeManager.FadeOut("Stage13");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 14)
        {
            Debug.Log("14");
            FadeManager.FadeOut("Stage14");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 15)
        {
            Debug.Log("15");
            FadeManager.FadeOut("Stage15");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 16)
        {
            Debug.Log("16");
            FadeManager.FadeOut("Stage16");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 17)
        {
            Debug.Log("17");
            FadeManager.FadeOut("Stage17");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 18)
        {
            Debug.Log("18");
            FadeManager.FadeOut("Stage18");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 19)
        {
            Debug.Log("19");
            FadeManager.FadeOut("Stage19");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        if (cntStage == 20)
        {
            Debug.Log("20");
            FadeManager.FadeOut("Stage20");
            Destroy(GameObject.FindGameObjectWithTag("TitleSound"));
        }
        //LoadingInstance = GameObject.Instantiate(LoadingPrefab) as GameObject;
        //SceneManager.LoadScene("GameMain");
    }

    public IEnumerator Flag()
    {
        yield return new WaitForSeconds(1);
        endFlag = false;
    }
}
