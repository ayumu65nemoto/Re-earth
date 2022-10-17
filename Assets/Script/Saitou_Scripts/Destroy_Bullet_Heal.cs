using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet_Heal : MonoBehaviour
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
            if(gameObject){
                Destroy(gameObject);
            }
            
        }

        if (collision.gameObject.tag == "Player")           //�v���C���[�ɓ��������狅��������
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<PlayerMove>().TakeHeal();
            
            
        }
    }
}
