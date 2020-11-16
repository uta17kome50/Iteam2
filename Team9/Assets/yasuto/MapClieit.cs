using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MapClieit : MonoBehaviour
{
    //オブジェクトを宣言
    public GameObject floorPrefab; //床
    public GameObject wallPrefab; //マップ内の壁
    public GameObject playerPrefab;//プレイヤー
                                   //public GameObject Enemy;
                                   //public GameObject Enemy1;
                                   //public GameObejct Enemy2;

    public GameObject GameManager;
    public GameObject[] EnemyObj;
    public GameObject[] REnemyObj;

    public GameState MapState;

    public GameObject Player;
    public GameObject Enemy;
    private int[,] player;
    private int[,] map;
    private int[,] enemy;

    public int playerPositionX = 0;
    public int playerPositionY = 0;




    // Start is called before the first frame update
    void Start()
    {

        map = CSVReader_Sam.csvIntDatas;
        player = CSVReader_Sam.csvIntDatas_playerPosition;
       /*
        map = new int[,]
        {
            { 0,0,0,0,0,0,0,0},
            { 0,1,1,1,4,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,4,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,4,0},
            { 0,0,0,0,0,0,0,0},
        };

        player = new int[,]
        {
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,2,0,0},
            { 0,0,0,0,0,0,0,0},
        };
        */

        enemy = new int[,]
        {
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
        };


        //各インデックスに代入された値を基に、壁の生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //インデックスの値が1の時、wallPrefabを生成
                if (map[i, j] == 1 || map[i, j] == 2 || map[i, j] == 4 || map[i, j] == 5)
                {
                    GameObject go = Instantiate(floorPrefab);
                    go.transform.position = new Vector2(i, j);

                }
                //インデックスの値が1の時、wallPrefabを生成
                if (map[i, j] == 0)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector2(i, j);

                }
                if (map[i, j] == 2)
                {
                    GameObject go = Instantiate(playerPrefab);
                    go.transform.position = new Vector2(i, j);
                }
                //if(map[i,j] == 3)
                //{
                //    GameObject go = Instantiate(Enemy);
                //    go.transform.position = new Vector2(i, j);
                //}
                //if(map[i,j] == 4)
                //{
                //    GameObject go = Instantiate(Enemy1);
                //    go.transform.position = new Vector2(i, j);
                //}
                //if (map[i, j] == 5)
                //{
                //    GameObject go = Instantiate(Enemy2);
                //    go.transform.position = new Vector2(i, j);
                //}
            }
        }
        for (int i = 0; i < player.GetLength(0); i++)
        {
            for (int j = 0; j < player.GetLength(1); j++)
            {
                if (player[i, j] == 2)
                {
                    GameObject go = Instantiate(playerPrefab);
                    go.transform.position = new Vector2(i, j);
                }
            }
        }
        Player = GameObject.FindGameObjectWithTag("Player");

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {

        GameObject[] EnemyObj = GameObject.FindGameObjectsWithTag("Enemy");

        if (GameManager == null) return;
        MapState = GameManager.GetComponent<Gamemanager1>().CurrentGameState;
        int moveX;
        int moveY;
        if (MapState == GameState.KeyInput)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveX = -1;
                moveY = 0;
                UpdatePlayerPosition(moveX, moveY);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                moveX = 1;
                moveY = 0;
                UpdatePlayerPosition(moveX, moveY);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                moveX = 0;
                moveY = 1;
                UpdatePlayerPosition(moveX, moveY);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                moveX = 0;
                moveY = -1;
                UpdatePlayerPosition(moveX, moveY);
            }
            //else
            //{
            //    moveX = 0;
            //    moveY = 0;
            //    UpdatePlayerPosition(moveX, moveY);
            //}
        }
        


    }

    void UpdatePlayerPosition(int moveX, int moveY)
    {
        enemy = new int[,]
        {
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
        };
        GameObject[] EnemyObj = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] REnemyObj = GameObject.FindGameObjectsWithTag("REnemy");
        for (int x = 0; x < EnemyObj.Length; ++x)
        {
            Vector2 ahoi = EnemyObj[x].transform.position;
            //Debug.Log(x);
            //Debug.Log(ahoi);
            enemy[(int)ahoi.x, (int)ahoi.y] = 1;
        }
        for (int x = 0; x < REnemyObj.Length; ++x)
        {
            Vector2 ahoi = REnemyObj[x].transform.position;
            //Debug.Log("R");
            //Debug.Log(ahoi);
            enemy[(int)ahoi.x, (int)ahoi.y] = 1;
        }
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        MapState = GameManager.GetComponent<Gamemanager1>().CurrentGameState;
        //プレイヤーの現在の一を取得する
        for (int i = 0; i < player.GetLength(0); i++)
        {
            for (int j = 0; j < player.GetLength(1); j++)
            {
                if (player[i, j] == 2)
                {
                    playerPositionX = i;
                    playerPositionY = j;
                }

            }
        }

        // 移動先が壁だった場合はreturnそれ以外の場合はプレイヤーをitweenによって移動させ,配列を更新する.
        if (map[playerPositionX + moveX, playerPositionY + moveY] == 0 || enemy[playerPositionX + moveX, playerPositionY + moveY] == 1 || map[playerPositionX + moveX, playerPositionY + moveY] == 3)
        {
            //SDebug.Log("壁");
            return;
        }
        else
        {
            player[playerPositionX, playerPositionY] = 0;
            player[playerPositionX + moveX, playerPositionY + moveY] = 2;

            Player.transform.position = new Vector2(playerPositionX + moveX, playerPositionY + moveY);
            GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);

            //for (int i = 0; i < player.GetLength(0); i++)
            //{
            //    for (int j = 0; j < player.GetLength(1); j++)
            //    {
            //        if (player[i, j] == 2)
            //        {
            //            GameObject go = Instantiate(playerPrefab);
            //            go.transform.position = new Vector2(i, j);
            //        }
            //    }
            //}
            //var moveHash = new Hashtable();
            ////Debug.Log(playerPositionX);
            //moveHash.Add("position", new Vector3(playerPositionX, playerPositionY));
            //moveHash.Add("time", 0.4f);
            //moveHash.Add("delay", 0.0f);
            //iTween.MoveTo(player, moveHash);

        }
    }

    void UpdateEnemyPosition()
    {

    }
}