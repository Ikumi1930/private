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

        if (Target)//Target‚ª‘¶İ‚·‚ê‚Î
        {
            transform.LookAt(Target.transform);//‚»‚Ì•ûŒü‚ğŒü‚­
        }

        this.transform.Translate(speed);
    }

    private void OnTriggerEnter(Collider other)//‰½‚©‚ª‚ ‚½‚Á‚½
    {
        if(other.tag == "Player")
        {
            Target = other.gameObject;//player‚ğTarget‚É“ü‚ê‚é
        }
        
    }

    private void OnTriggerExit(Collider other)//“–‚½‚è”»’è‚ÌŠO‚Éo‚½ê‡
    {
        if(other.tag == "Player")//player‚È‚ç
        {
            Target = null;
        }
        
    }
}
