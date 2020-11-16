﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

using UnityEngine.UI;//追加

public class PlayerContlloer : MonoBehaviour
{
    public LaserScript LaserPrefab;
    public MissileScript MissilePrefab;

    //    Vector3 MOVEX = new Vector3(0.64f, 0, 0); // x軸方向に１マス移動するときの距離
    //    Vector3 MOVEY = new Vector3(0, 0.64f, 0); // y軸方向に１マス移動するときの距離
    public GameObject GameManager;
    public GameState PlayerState;
    public GameObject mane;
    GameObject GameManager1;
    Gamemanager1 script;
    public float speed = 1f;     // 移動速度
    //Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    //Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    Animator animator;   // アニメーション
    Rigidbody2D rb;
    private List<GameObject> weaponList = new List<GameObject>();
    //Stack<string> StackBalletDitection = new Stack<string>();//弾の方向を格納
    //Stack<string> StackBalletType = new Stack<string>();//弾の種類を格納
    struct Ballet
    {
        public Vector3 Direction;
        public string Type;
        public Ballet(Vector3 dir, string btype)
        {
            Direction = dir;
            Type = btype;
        }
    }
    List<Ballet> balletList = new List<Ballet>();
    Image stock1, stock2, stock3;
    private GameObject activeWeapon;


    // Use this for initialization
    void Start()
    {
        //target = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //オブジェクトの取得
        stock1 = GameObject.Find("stock1").GetComponent<Image>();
        stock2 = GameObject.Find("stock2").GetComponent<Image>();
        stock3 = GameObject.Find("stock3").GetComponent<Image>();

        mane = GameObject.Find("GameManager");
        GameManager1 = GameObject.Find("GameManager");
        script = GameManager1.GetComponent<Gamemanager1>();
    }

    // Update is called once per frame
    void Update()
    {

        //// ① 移動中かどうかの判定。移動中でなければ入力を受付
        //if (transform.position == target)
        //{
        //    SetTargetPosition();
        //}

        Move();
        Attack();
        Death();
        int turn = script.turn;

        if (turn <= 0)
            Destroy(this.gameObject);
    }

    // ② 入力に応じて移動後の位置を算出
    //void SetTargetPosition()
    //{

    //    prevPos = target;

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        target = transform.position + MOVEX;
    //        //SetAnimationParam(1);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        target = transform.position - MOVEX;
    //        //SetAnimationParam(2);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        target = transform.position + MOVEY;
    //        //SetAnimationParam(3);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        target = transform.position - MOVEY;
    //        //SetAnimationParam(0);
    //        return;
    //    }
    //}

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    //void SetAnimationParam(int param)
    //{
    //    animator.SetInteger("WalkParam", param);
    //}

    // ③ 目的地へ移動する
    void Move()
    {
        //GameManager = GameObject.FindGameObjectWithTag("GameManager");
        //PlayerState = GameManager.GetComponent<Gamemanager1>().CurrentGameState;
        ////Debug.Log(PlayerState);
        //if (Time.timeScale != 0)
        //if (PlayerState == GameState.KeyInput)
        //{
        //    if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        //    {
        //        if (transform.position.x != 6)
        //        {
        //            transform.position += transform.right * 1.0f;
        //            GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);
        //            //UpdatePlayerPossision(velocity.x, velocity.y);
        //        }

        //    }
        //    else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        //    {
        //        if (transform.position.x != 1)
        //        {
        //            transform.position += transform.right * -1.0f;
        //            GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);
        //            //UpdatePlayerPossision(velocity.x, velocity.y);
        //        }

        //    }
        //    else if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
        //    {
        //        if (transform.position.y != 6)
        //        {
        //            transform.position += transform.up * 1.0f;
        //            GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);
        //            // UpdatePlayerPossision(velocity.x, velocity.y);
        //        }

        //    }
        //    else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
        //    {
        //        if (transform.position.y != 1)
        //        {
        //            transform.position += transform.up * -1.0f;
        //            GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);
        //            // UpdatePlayerPossision(velocity.x, velocity.y);
        //        }

        //    }




        // rb.velocity = velocity;
        //transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
    //攻撃
    void Attack()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        PlayerState = GameManager.GetComponent<Gamemanager1>().CurrentGameState;

        if (PlayerState == GameState.KeyInput)

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 1"))
            {
                if (balletList.Count <= 0)
                {
                    return;
                }
                RemoveStockUI();
                var dir = balletList[0].Direction;
                var type = balletList[0].Type;
                Debug.Log(dir + " >> " + type);
                balletList.RemoveAt(0);
                GameObject prefab = null;
                switch (type)
                {
                    case "Laser":
                        prefab = LaserPrefab.gameObject;
                        break;
                    case "Missile":
                        prefab = MissilePrefab.gameObject;
                        break;
                }

                var obj = Instantiate(prefab, transform.position + dir * 1.0f, Quaternion.identity);
                obj.transform.right = dir;
                activeWeapon = obj.gameObject;
                GameManager.GetComponent<Gamemanager1>().SetCurrentState(GameState.PlayerTurn);

            }
    }
    //死亡
    void Death()
    {
        //キャパオーバーした時
        if (balletList.Count > 3)
        {

            Destroy(mane);
            Destroy(this.gameObject);
            FadeManager.FadeOut("GameOver");
        }
    }
    private Vector3 GetDirection(string dir)
    {
        switch (dir)
        {
            case "Right":
                return Vector3.right;
            case "Left":
                return Vector3.left;
            case "Up":
                return Vector3.up;
            case "Down":
                return Vector3.down;
        }
        return Vector3.zero;
    }
    // 衝突時のXY平面の角度計算
    public float GetDeg_XY(Vector3 vector)
    {
        var vec = (new Vector2(vector.x, vector.y)).normalized * 100.0f;
        float rad = Mathf.Atan2(vector.y, vector.x);
        return rad * Mathf.Rad2Deg;
    }
    //方向を検知
    private string Direction(float deg)
    {
        if (45.0f < deg && deg <= 135.0f) return ("Down");
        if (135.0f < deg || deg <= -135.0f) return ("Right");
        if (-135.0f < deg && deg <= -45.0f) return ("Up");
        if (-45.0f < deg && deg <= 45.0f) return ("Left");
        return null;
    }
    //ストックUIの変更
    private void AddStockUI(GameObject prefab)
    {
        weaponList.Add(Instantiate(prefab, Vector3.one * 1000, Quaternion.identity));
        if (0 < weaponList.Count)
        {
            weaponList[0].transform.position = stock1.transform.position - Camera.main.transform.forward;
        }
        if (1 < weaponList.Count)
        {
            weaponList[1].transform.position = stock2.transform.position - Camera.main.transform.forward/*rectTransform.anchoredPosition*/;
        }
        if (2 < weaponList.Count)
        {
            weaponList[2].transform.position = stock3.transform.position - Camera.main.transform.forward/*rectTransform.anchoredPosition*/;
        }
        Debug.Log("stock1"+stock1.transform.position+"stock2"+stock2.transform.position +"stock3"+ stock3.transform.position);

    }
    private void RemoveStockUI()
    {

        if (weaponList.Count <= 0) return;
        for (int i = weaponList.Count - 1; 0 <= i; i--)
        {
            if (0 <= i - 1)
            {
                Debug.Log((i) + ": " + weaponList[i].transform.position + " / " + (i-1)+ ": " + weaponList[i-1].transform.position);
                weaponList[i].transform.position = weaponList[i-1].transform.position;
            }
        }
        Destroy(weaponList[0].gameObject);
        weaponList.RemoveAt(0);


    }
    private GameObject GetWeaponPrefab(string name, string dir)
    {
        var s = name.ToUpper() + "_" + dir.ToUpper();
        Debug.Log(s);
        return Resources.Load<GameObject>("Stocks/" + name.ToUpper() + "_" + dir.ToUpper());

    }

    //弾と衝突時
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("REnemy"))
        {
            Destroy(mane);

            Destroy(gameObject);
        }
        if (other.gameObject == activeWeapon) return;
        Debug.Log("hit");
        switch (other.gameObject.tag)
        {
            case "Missile":
            case "Laser":
                //if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("Laser"))
                //{

                if (other.contacts.Length <= 0) return;//衝突してないならリターン
                var start = other.contacts[0].point;
                var vector = Vector2.zero;
                // すべての衝突位置を調べて、向き（ベクトル）を求める
                for (int i = 0; i < other.contacts.Length - 1; i++)
                {
                    var point_start = (other.contacts[i].point);
                    var point_end = (other.contacts[i + 1].point);
                    vector += (point_end - point_start);
                    Debug.Log(point_start + " / " + point_end);
                }

                // 中点の計算
                vector /= 2.0f;
                Vector3 pos = start + vector;

                // 上記の「中点の計算の下から記入」
                float deg = GetDeg_XY(pos - transform.position);

                var dir = Direction(deg);
                Debug.Log("Direction>> " + dir);
                Debug.Log("Type>>" + other.gameObject.tag);
                balletList.Add(new Ballet(GetDirection(dir), other.gameObject.tag));
                var prefab = GetWeaponPrefab(other.gameObject.tag, dir);
                if (prefab != null)
                {
                    AddStockUI(prefab);
                }

                break;

        }
    }

}
