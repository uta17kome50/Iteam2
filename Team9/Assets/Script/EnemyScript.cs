using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Sprite LezarEnemy;
    [SerializeField]
    Sprite MissileEnemy;

    Rigidbody2D rb;

    public LaserScript LezarPrefab;
    public MissileScript MissilePrefab;

    public GameObject Player;

    SpriteRenderer MainSpriteRenderer;
    public string EnemyName;
    public string Direction;
    public bool IsMovePlayer;
    public int CountLaser;

    private MissileScript activeMissile;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        IsMovePlayer = false;
        if (EnemyName == "Laser")
        {
            MainSpriteRenderer.sprite = LezarEnemy;
        }
        if (EnemyName == "Missile")
        {
            MainSpriteRenderer.sprite = MissileEnemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.transform.position);
        Debug.Log(rb.transform.position);
        ChangeSprite();
        if (IsMovePlayer == true)
        {
            switch (Direction)
            {
                case "Right":
                    if (rb.transform.position.x < Player.transform.position.x &&
                        rb.transform.position.y == Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            if (CountLaser == 3)
                            {
                                var obj = Instantiate(LezarPrefab, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                        if (EnemyName == "Missile")
                        {
                            if (activeMissile != null) break;
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            activeMissile = obj.GetComponent<MissileScript>();
                        }
                    }
                    break;
                case "Down":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y > Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            if (CountLaser == 3)
                            {
                                var obj = Instantiate(LezarPrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                        if (EnemyName == "Missile")
                        {
                            if (activeMissile != null) break;
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, -2.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            activeMissile = obj.GetComponent<MissileScript>();
                        }
                    }
                    break;
                case "Left":
                    if (rb.transform.position.x > Player.transform.position.x &&
                        rb.transform.position.y == Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            if (CountLaser == 3)
                            {
                                var obj = Instantiate(LezarPrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                        if (EnemyName == "Missile")
                        {
                            if (activeMissile != null) break;
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(-2.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            activeMissile = obj.GetComponent<MissileScript>();
                        }
                    }
                    break;
                case "Up":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y < Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            if (CountLaser == 3)
                            {
                                var obj = Instantiate(LezarPrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                        if (EnemyName == "Missile")
                        {
                            if (activeMissile != null) break;
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            activeMissile = obj.GetComponent<MissileScript>();
                        }
                    }
                    break;
            }
            IsMovePlayer = false;
        }
    }

    void ChangeSprite()
    {
        Quaternion q = transform.rotation;
        if (Direction == "Right")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Direction == "Down")
        {
            //mainSpriteRender.sprite = defZombie_l;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 270f);
        }
        if (Direction == "Left")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 180f);
        }
        if (Direction == "Up")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 270.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 90f);
        }
        transform.rotation = q;
    }

    public string RetrunDirection()
    {
        return Direction;
    }

    void OnCollision2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
    }
}
