using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")              //�ǂɓ���������e��������
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")           //�v���C���[�ɓ��������狅��������
        {
            Destroy(gameObject);
            //GetComponent<PlayerMove>().TakeDamage(transform.root);
        }
    }
}
