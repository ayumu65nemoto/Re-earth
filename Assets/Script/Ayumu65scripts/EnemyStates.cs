using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStates : MonoBehaviour
{
    //�@�G��HP
    [SerializeField]
    private int hp = 3;

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public int GetHp()
    {
        return hp;
    }
}
