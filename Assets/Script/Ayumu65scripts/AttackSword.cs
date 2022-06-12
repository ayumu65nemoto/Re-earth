using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            //Debug.Log("�G�ɓ�������");
            col.GetComponent<EnemyMove>().SetState(EnemyMove.EnemyState.Damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
