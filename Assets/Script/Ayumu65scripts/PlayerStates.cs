using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

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
        
    }
}
