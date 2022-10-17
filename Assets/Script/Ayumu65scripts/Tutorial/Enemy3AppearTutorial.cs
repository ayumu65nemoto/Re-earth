using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AppearTutorial : MonoBehaviour
{
    public GameObject enemy3;
    public EnemyMoveTutorial enemyMoveTutorial;
    public EnemyMove2Tutorial enemyMove2Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        enemy3.SetActive(false);
        //enemyMoveTutorial = GetComponent<EnemyMoveTutorial>();
        //enemyMove2Tutorial = GetComponent<EnemyMove2Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        var deadCounts = enemyMoveTutorial.deadCount + enemyMove2Tutorial.deadCount2;
        if (deadCounts == 2)
        {
            enemy3.SetActive(true);
        }
    }
}
