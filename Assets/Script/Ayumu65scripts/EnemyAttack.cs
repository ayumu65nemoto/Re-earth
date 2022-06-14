using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("������");
            col.GetComponent<PlayerMove>().TakeDamage(transform.root);
        }
    }
}
