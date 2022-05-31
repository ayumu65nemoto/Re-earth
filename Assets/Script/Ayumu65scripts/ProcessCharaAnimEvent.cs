using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCharaAnimEvent : MonoBehaviour
{
    private PlayerMove playerMove;
    [SerializeField]
    private Collider cCol;
    [SerializeField]
    private Transform equip;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip attackSound;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        cCol = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
    }
    void AttackStart()
    {
        if (cCol != null)
        {
            cCol.enabled = true;
            if (equip.GetChild(0).CompareTag("Sword"))
            {
                audioSource.PlayOneShot(attackSound);
            }
        }
    }

    public void AttackEnd()
    {
        if (cCol != null)
        {
            cCol.enabled = false;
        }
    }

    void StateEnd()
    {
        playerMove.SetState(PlayerMove.MyState.Normal);
    }

    void EndDamage()
    {
        playerMove.SetState(PlayerMove.MyState.Normal);
    }

    public void SetCollider(Collider col)
    {
        cCol = col;
    }

    /*public void ReadyShot()
    {
        playerMove.SetReadyShot();
    }*/
}
