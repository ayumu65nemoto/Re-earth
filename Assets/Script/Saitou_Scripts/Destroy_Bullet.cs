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
        if (collision.gameObject.tag == "Wall")              //•Ç‚É“–‚½‚Á‚½‚ç’e‚ªÁ‚¦‚é
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")           //ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½‚ç‹…‚ªÁ‚¦‚é
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMove>().TakeDamage(transform.root);
        }
    }
}
