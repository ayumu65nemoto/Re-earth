using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Player")
    //    {
    //        col.GetComponent<PlayerMove>().TakeDamage(transform.root);
    //        Destroy(gameObject);
    //    }

    //}
}
