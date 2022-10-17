using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AppearTutorial : MonoBehaviour
{
    public GameObject enemy2;
    public AppearScript appearScript;

    // Start is called before the first frame update
    void Start()
    {
        enemy2.SetActive(false);
        //appearScript = GetComponent<AppearScript>();
    }

    // Update is called once per frame
    void Update()
    {
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 1)
        {
            enemy2.SetActive(true);
        }
    }
}
