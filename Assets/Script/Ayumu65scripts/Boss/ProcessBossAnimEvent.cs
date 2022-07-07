using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessBossAnimEvent : MonoBehaviour
{
    private BossMove bossMove;
    [SerializeField]
    private SphereCollider sCol;
    // Start is called before the first frame update
    void Start()
    {
        bossMove = GetComponent<BossMove>();
    }

    void AttackStart()
    {
        sCol.enabled = true;
        //Debug.Log("S");
    }

    public void AttackEnd()
    {
        sCol.enabled = false;
        //Debug.Log("E");
    }

    public void StateEnd()
    {
        bossMove.SetState(BossMove.EnemyState.Freeze);
    }

    public void EndDamage()
    {
        bossMove.SetState(BossMove.EnemyState.Walk);
    }
}
