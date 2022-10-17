using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    const int MIN = 0;
    const int MAX = 100;

    // Start is called before the first frame update
    void Start()
    {
        //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        // 最大値を超えたら最大値を渡す
        currentHp = System.Math.Min(currentHp, MAX);
        // 最小値を下回ったら最小値を渡す
        currentHp = System.Math.Max(currentHp, MIN);
    }
}
