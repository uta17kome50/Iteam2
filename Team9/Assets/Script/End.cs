﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        Scene();
    }

    void Scene()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            FadeManager.FadeOut("Title");
        }
    }
}
