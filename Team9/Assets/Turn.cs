using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Turn : MonoBehaviour
{
    GameObject GameManager;
    Gamemanager1 script;
    public GameObject turnobject;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        script = GameManager.GetComponent<Gamemanager1>();
    }

    // Update is called once per frame
    void Update()
    {
        int turn2 = script.turn;
       
       
        Text turn1 = turnobject.GetComponent<Text>();
        turn1.text = "turn" + turn2;
    }
}
