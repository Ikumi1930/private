using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject Enemy;
    private GameObject EnemyInstance;

    //public Transform Player;
    //public float rotationSpeed = 3f;

    //public Transform EnemyPlace;//Enemyの場所

    //タイマー
    //float TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        SpownEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Player != null)
        //{
        //    Vector3 direction = Player.position - transform.position;
        //    direction.y = 0;

        //    Quaternion targetRotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
        //}


        //TimeCount += Time.deltaTime;
        //if (TimeCount > 5)
        //{
        //    //Quaternion.identity=回転を０にする
        //    Instantiate(Enemy, EnemyPlace.position, Quaternion.identity);
        //    TimeCount = 0;
        //}
    }

    void SpownEnemy()
    {
        //ボスが既に存在しない場合にのみ生成
        if(EnemyInstance == null)
        {
            //ボスを指定した位置に生成
            EnemyInstance = Instantiate(Enemy,new Vector3(0,0,8), Quaternion.identity);

            //敵を180度回転させる
            EnemyInstance.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

}
