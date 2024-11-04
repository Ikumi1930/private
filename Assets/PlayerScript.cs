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

    //�O����(x,y,z)�̒l
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
        Move();//void Move()�̏���������
        Rotation();
        Attack();
        //�J�����̍��W�Ɏ����̍��W������
        Camera.transform.position = transform.position;
    }

    void Move()
    {
        if (canMove==false)
        {
            return;//�������~�߂�
        }

        //�����Œl�����񃊃Z�b�g�����
        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun = false;

        //�O�ړ�
        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            MoveSet();
        }
        //���ړ�
        if (Input.GetKey(KeyCode.S))
        { 
            rot.y = 180;
            MoveSet();

        }
        //���ړ�
        if (Input.GetKey(KeyCode.A))
        {         
            rot.y = -90;
            MoveSet();
        }
        //�E�ړ�
        if (Input.GetKey(KeyCode.D))
        {          
            rot.y = 90;
            MoveSet();
        }
      
        transform.Translate(speed);
        //flag���Z�b�g����
        PlayerAnimator.SetBool("run", isRun);
    }

    void MoveSet()
    {
        //�O�����̂�������PlayerSpeed���������Ă�
        speed.z = PlayerSpeed;

        //�����̌����Ă�����̓J������rot�Őݒ肵���l�𑫂�������
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
        //�����̉�]�ɉ��Z���Ă���
        Camera.transform.eulerAngles += speed;

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))//space�L�[�������ꂽ�u�Ԃ̏���
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

