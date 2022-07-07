using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("������");
            col.GetComponent<PlayerMove>().TakeBossDamage(transform.root);
        }
    }
}
