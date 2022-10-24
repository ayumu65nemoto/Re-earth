using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacterTutorial : MonoBehaviour
{
    private EnemyMoveTutorial enemyMoveTutorial;

    // Start is called before the first frame update
    void Start()
    {
        enemyMoveTutorial = GetComponentInParent<EnemyMoveTutorial>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            EnemyMoveTutorial.EnemyState state = enemyMoveTutorial.GetState();

            if (state == EnemyMoveTutorial.EnemyState.Wait || state == EnemyMoveTutorial.EnemyState.Walk)
            {
                //Debug.Log("�v���C���[����");
                enemyMoveTutorial.SetState(EnemyMoveTutorial.EnemyState.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
            enemyMoveTutorial.SetState(EnemyMoveTutorial.EnemyState.Wait);
        }
    }
}
