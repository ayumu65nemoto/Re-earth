using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAE : MonoBehaviour
{
    private PlayerMove playerMove;
    [SerializeField]
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        capsuleCollider.enabled = false;

    }
    void AttackStart()
    {
        capsuleCollider.enabled = true;
    }

    public void AttackEnd()
    {
        capsuleCollider.enabled = false;
    }

    void StateEnd()
    {
        playerMove.SetState(PlayerMove.MyState.Normal);
    }
    public void EndDamage()
    {
        playerMove.SetState(PlayerMove.MyState.Normal);
    }
}
