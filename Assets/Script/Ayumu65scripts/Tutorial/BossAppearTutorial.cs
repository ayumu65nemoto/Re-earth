using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppearTutorial : MonoBehaviour
{
    public GameObject boss;
    public AppearScript appearScript;

    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
        //appearScript = GetComponent<AppearScript>();
    }

    // Update is called once per frame
    void Update()
    {
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 3)
        {
            boss.SetActive(true);
        }
    }
}
