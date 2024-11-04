using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    //三次元(x,y,z)の値
    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimator;
    bool isRun;

    public Collider WeaponCollider;
    bool canMove = true;

    public AudioSource audioSource;
    public AudioClip AttackSE;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//void Move()の処理をする
        Rotation();
        Attack();
        //カメラの座標に自分の座標を入れる
        Camera.transform.position = transform.position;
    }

    void Move()
    {
        if (canMove==false)
        {
            return;//動きを止める
        }

        //ここで値が毎回リセットされる
        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun = false;

        //前移動
        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            MoveSet();
        }
        //後ろ移動
        if (Input.GetKey(KeyCode.S))
        { 
            rot.y = 180;
            MoveSet();

        }
        //左移動
        if (Input.GetKey(KeyCode.A))
        {         
            rot.y = -90;
            MoveSet();
        }
        //右移動
        if (Input.GetKey(KeyCode.D))
        {          
            rot.y = 90;
            MoveSet();
        }
      
        transform.Translate(speed);
        //flagをセットする
        PlayerAnimator.SetBool("run", isRun);
    }

    void MoveSet()
    {
        //三次元のｚだけにPlayerSpeedが代入されてる
        speed.z = PlayerSpeed;

        //自分の向いてる方向はカメラとrotで設定した値を足したもの
        transform.eulerAngles = Camera.transform.eulerAngles + rot;
        isRun = true;
    }


    void Rotation()
    {
        var speed = Vector3.zero;
 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -RotationSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed;
        }
        //自分の回転に加算していく
        Camera.transform.eulerAngles += speed;

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))//spaceキーが押された瞬間の処理
        {
            PlayerAnimator.SetBool("attack", true);
            canMove = false;
            audioSource.PlayOneShot(AttackSE);
        }
    }

    void WeaponON()
    {
        WeaponCollider.enabled = true;
    }

    void WeaponOFF()
    {
        WeaponCollider.enabled = false;
        PlayerAnimator.SetBool("attack", false);
        CanMove();
    }

    void CanMove()
    {
        canMove = true;
    }

}

