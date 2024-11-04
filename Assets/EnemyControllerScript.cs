using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{ 
    public float time;

    public float EnemySpeed;

    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
       // Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = EnemySpeed;

        if (Target)//Target�����݂����
        {
            transform.LookAt(Target.transform);//���̕���������
        }

        this.transform.Translate(speed);
    }

    private void OnTriggerEnter(Collider other)//����������������
    {
        if(other.tag == "Player")
        {
            Target = other.gameObject;//player��Target�ɓ����
        }
        
    }

    private void OnTriggerExit(Collider other)//�����蔻��̊O�ɏo���ꍇ
    {
        if(other.tag == "Player")//player�Ȃ�
        {
            Target = null;
        }
        
    }
}
