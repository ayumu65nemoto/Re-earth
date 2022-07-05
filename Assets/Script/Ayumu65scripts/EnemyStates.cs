using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    //@“G‚ÌHP
    [SerializeField]
    private int hp = 3;
    //@“G‚ÌUŒ‚—Í
    [SerializeField]
    public int Power;
    public int attackPower;
    private int powerCount;

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
        powerCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerCount > 0)
        {
            StartCoroutine("SpeedUp");
            powerCount -= 1;
        }
    }

    IEnumerator SpeedUp()
    {
        attackPower *= 5;
        yield return new WaitForSeconds(3.0f);
        attackPower = Power;
    }
}
