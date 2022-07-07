using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacterII : MonoBehaviour
{
    private EnemyMove2 enemyMove2;
    private EnemyShot enemyShot;
    int BallShotCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyShot = GetComponentInParent<EnemyShot>();
        enemyMove2 = GetComponentInParent<EnemyMove2>();
        BallShotCount = 0;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            EnemyMove2.EnemyState state = enemyMove2.GetState();

            if (state == EnemyMove2.EnemyState.Wait || state == EnemyMove2.EnemyState.Walk)
            {
                //Debug.Log("ÉvÉåÉCÉÑÅ[î≠å©");
                enemyMove2.SetState(EnemyMove2.EnemyState.Chase, col.transform);
            }

            if (BallShotCount % 120 == 0)
            {
                enemyShot.BallShot();
            }

            BallShotCount += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("å©é∏Ç§");
            enemyMove2.SetState(EnemyMove2.EnemyState.Wait);
        }
    }
}
