using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    public GameObject boss;
    public AppearScript appearScript;
    // Start is called before the first frame update
    void Start()
    {
        //ボスを非アクティブにしておく
        boss.SetActive(false);
        appearScript = GetComponent<AppearScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //雑魚敵を一定数倒すとボスをアクティブにする
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 10)
        {
            boss.SetActive(true);
        }
    }
}
