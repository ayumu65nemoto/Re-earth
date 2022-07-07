using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            //Debug.Log("“G‚É“–‚½‚Á‚½");
            col.GetComponent<EnemyMove>().SetState(EnemyMove.EnemyState.Damage);
            col.GetComponent<EnemyMove>().TakeDamage();
        }

        if (col.tag == "Enemy2")
        {
            col.GetComponent<EnemyMove2>().SetState(EnemyMove2.EnemyState.Damage);
            col.GetComponent<EnemyMove2>().TakeDamage();
        }

        if (col.tag == "Boss")
        {
            col.GetComponent<BossMove>().SetState(BossMove.EnemyState.Damage);
            col.GetComponent<BossMove>().TakeDamage();
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
