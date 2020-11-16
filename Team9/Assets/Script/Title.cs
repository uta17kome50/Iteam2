using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
           

        FadeManager.FadeIn();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            
            Application.Quit();
        }
        Scene();
    }

    void Scene()
    {
        if(Input.GetKeyDown("joystick button 7"))
        {
            
            FadeManager.FadeOut("Stage1");
        }
    }
}
