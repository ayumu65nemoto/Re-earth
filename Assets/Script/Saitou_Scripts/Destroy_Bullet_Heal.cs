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
        if (collision.gameObject.tag == "Wall")              //壁に当たったら弾が消える
        {
            if(gameObject){
                Destroy(gameObject);
            }
            
        }

        if (collision.gameObject.tag == "Player")           //プレイヤーに当たったら球が消える
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<PlayerMove>().TakeHeal();
            
            
        }
    }
}
