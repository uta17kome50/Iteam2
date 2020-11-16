using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class goal : MonoBehaviour
{
    public GameObject mane;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mane = GameObject.Find("GameManager");

        player = GameObject.Find("Player(Clone)");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(mane);
            Destroy(player);


            FadeManager.FadeOut("Stage2");

        }
    }
}
