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
        //�{�X���A�N�e�B�u�ɂ��Ă���
        boss.SetActive(false);
        appearScript = GetComponent<AppearScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //�G���G����萔�|���ƃ{�X���A�N�e�B�u�ɂ���
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 10)
        {
            boss.SetActive(true);
        }
    }
}
