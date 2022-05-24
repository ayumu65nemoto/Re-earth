using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PleaseEnter : MonoBehaviour
{
    private float time2 = 3.00f;

    void Update()
    {
        if (0 < time2)
        {
            time2 -= Time.deltaTime;
        }
        else if (time2 < 0)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Title");
            }

        }
    }
}
