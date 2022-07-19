using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    public PlayerMove playerMove;

    void Start()
    {
        //playerMove = GetComponent<PlayerMove>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")              //�ǂɓ���������e��������
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")           //�v���C���[�ɓ��������狅��������
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMove>().TakeDamage(transform.root);
        }
    }
}
