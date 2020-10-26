using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContlloer : MonoBehaviour
{
    Vector3 MOVEX = new Vector3(0.64f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 0.64f, 0); // y軸方向に１マス移動するときの距離
    float step = 2f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    Animator animator;   // アニメーション
    Stack<string> stackballetdirection = new Stack<string>();//弾の方向を格納
    Stack<string> stackballetType = new Stack<string>();//弾の種類を格納


    // Use this for initialization
    void Start()
    {
        target = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();
        Attack();
        Death();
    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {

        prevPos = target;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            target = transform.position + MOVEX;
            //SetAnimationParam(1);
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            target = transform.position - MOVEX;
            //SetAnimationParam(2);
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            target = transform.position + MOVEY;
            //SetAnimationParam(3);
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            target = transform.position - MOVEY;
            //SetAnimationParam(0);
            return;
        }
    }

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    //void SetAnimationParam(int param)
    //{
    //    animator.SetInteger("WalkParam", param);
    //}

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    } 
    //攻撃
    void Attack()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            string obj = stackballetdirection.Pop();
        }
    }
    //死亡
    void Death()
    {
        //キャパオーバーした時
        if (stackballetdirection.Count > 4)
        {
            Destroy(this.gameObject);
        }
    }
    //弾と衝突時
   void OnCollision2D(Collision other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            //stackballetdirection.Push();
            //stackballetType.Push();
        }

        if (other.gameObject.CompareTag("Lazer"))
        {
            //stackballetdirection.Push();
            //stackballetType.Push();
        }
    }

}
