using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacterII : MonoBehaviour
{
    private EnemyShot enemyShot;
    int BallShotCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyShot = GetComponentInParent<EnemyShot>();
        BallShotCount = 0;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
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
            Debug.Log("Œ©Ž¸‚¤");
        }
    }
}
