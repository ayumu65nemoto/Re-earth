using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoresceneScript : MonoBehaviour
{

    private float scenetime = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scenetime -= Time.deltaTime;
        if (scenetime <= 0)
        {
            SceneManager.LoadScene("Result");
            scenetime = 9.0f;
        }
    }
}
