using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private EnemyMove enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            EnemyMove.EnemyState state = enemyMove.GetState();

            if (state == EnemyMove.EnemyState.Wait || state == EnemyMove.EnemyState.Walk)
            {
                //Debug.Log("プレイヤー発見");
                enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            enemyMove.SetState(EnemyMove.EnemyState.Wait);
        }
    }
}
