using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessEnemyAnimEvent : MonoBehaviour
{
    private EnemyMove enemyMove;
    [SerializeField]
    private SphereCollider sCol;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
    }

    void AttackStart()
    {
        sCol.enabled = true;
    }

    public void AttackEnd()
    {
        sCol.enabled = false;
    }

    public void StateEnd()
    {
        enemyMove.SetState(EnemyMove.EnemyState.Freeze);
    }

    public void EndDamage()
    {
        enemyMove.SetState(EnemyMove.EnemyState.Walk);
    }
}
