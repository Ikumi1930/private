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

        if (Target)//Targetが存在すれば
        {
            transform.LookAt(Target.transform);//その方向を向く
        }

        this.transform.Translate(speed);
    }

    private void OnTriggerEnter(Collider other)//何かがあたった時
    {
        if(other.tag == "Player")
        {
            Target = other.gameObject;//playerをTargetに入れる
        }
        
    }

    private void OnTriggerExit(Collider other)//当たり判定の外に出た場合
    {
        if(other.tag == "Player")//playerなら
        {
            Target = null;
        }
        
    }
}
