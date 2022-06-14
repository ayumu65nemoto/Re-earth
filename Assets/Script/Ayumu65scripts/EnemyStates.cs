using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    //�@�G��HP
    [SerializeField]
    private int hp = 3;
    //�@�G�̍U����
    [SerializeField]
    private int attackPower = 1;

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public int GetHp()
    {
        return hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
