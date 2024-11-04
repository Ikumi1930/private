using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�摜�A�e�L�X�g���������߂̂��

public class StatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSource;
    public AudioClip HitSE;
    //�����ł����悤�ɂ���
    public string TagName;

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            //�G�̍��W�ɃG�t�F�N�g������
            effect.transform.position = transform.position;
            Destroy(effect, 5);
            Destroy(Main);
        }

        float percent = (float)HP / MaxHP;//(float)�����_�ɒu�������Čv�Z�ł���
        HPGage.fillAmount = percent;
    }

    private void OnTriggerEnter(Collider other)//�����蔻��̏��
    {
        if (other.tag == TagName)//��������Weapon
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
