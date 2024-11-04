using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//画像、テキストを扱うためのやつ

public class StatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSource;
    public AudioClip HitSE;
    //自分でつけれるようにする
    public string TagName;

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            //敵の座標にエフェクトを入れる
            effect.transform.position = transform.position;
            Destroy(effect, 5);
            Destroy(Main);
        }

        float percent = (float)HP / MaxHP;//(float)小数点に置き換えて計算できる
        HPGage.fillAmount = percent;
    }

    private void OnTriggerEnter(Collider other)//当たり判定の情報
    {
        if (other.tag == TagName)//ここだとWeapon
        {
            Damage();
        }
    }

    void Damage()
    {
        audioSource.PlayOneShot(HitSE);
        HP--;
    }
}
