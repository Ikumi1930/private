using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject Enemy;
    private GameObject EnemyInstance;

    //public Transform Player;
    //public float rotationSpeed = 3f;

    //public Transform EnemyPlace;//Enemy�̏ꏊ

    //�^�C�}�[
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
        //    //Quaternion.identity=��]���O�ɂ���
        //    Instantiate(Enemy, EnemyPlace.position, Quaternion.identity);
        //    TimeCount = 0;
        //}
    }

    void SpownEnemy()
    {
        //�{�X�����ɑ��݂��Ȃ��ꍇ�ɂ̂ݐ���
        if(EnemyInstance == null)
        {
            //�{�X���w�肵���ʒu�ɐ���
            EnemyInstance = Instantiate(Enemy,new Vector3(0,0,8), Quaternion.identity);

            //�G��180�x��]������
            EnemyInstance.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

}
