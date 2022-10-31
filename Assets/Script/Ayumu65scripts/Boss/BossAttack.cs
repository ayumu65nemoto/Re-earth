using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerMove>().TakeBossDamage(transform.root);
        }
    }
}
