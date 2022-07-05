using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacterII : MonoBehaviour
{
    private EnemyMove2 enemyMove2;
    int BallShotCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove2 = GetComponentInParent<EnemyMove2>();
        BallShotCount = 0;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (BallShotCount % 120 == 0)
            {
                enemyMove2.BallShot();
            }

            BallShotCount += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Œ©Ž¸‚¤");
        }
    }
}
