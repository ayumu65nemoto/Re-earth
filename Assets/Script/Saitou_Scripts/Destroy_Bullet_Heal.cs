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
        if (collision.gameObject.tag == "Wall")              //ï«Ç…ìñÇΩÇ¡ÇΩÇÁíeÇ™è¡Ç¶ÇÈ
        {
            if(gameObject){
                Destroy(gameObject);
            }
            
        }

        if (collision.gameObject.tag == "Player")           //ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇ¡ÇΩÇÁãÖÇ™è¡Ç¶ÇÈ
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<PlayerMove>().TakeHeal();
            
            
        }
    }
}
