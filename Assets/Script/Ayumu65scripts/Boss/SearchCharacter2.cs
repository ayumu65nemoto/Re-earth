using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter2 : MonoBehaviour
{
    private BossMove bossMove;

    // Start is called before the first frame update
    void Start()
    {
        bossMove = GetComponentInParent<BossMove>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            BossMove.EnemyState state = bossMove.GetState();

            if (state == BossMove.EnemyState.Wait || state == BossMove.EnemyState.Walk)
            {
                //Debug.Log("ÉvÉåÉCÉÑÅ[î≠å©");
                bossMove.SetState(BossMove.EnemyState.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("å©é∏Ç§");
            bossMove.SetState(BossMove.EnemyState.Wait);
        }
    }
}
