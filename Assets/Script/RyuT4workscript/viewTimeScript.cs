using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class viewTimeScript : MonoBehaviour
{

    private float endtime = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endtime -= Time.deltaTime;
        if(endtime <= 0)
        {
            SceneManager.LoadScene("Title");
            endtime = 60.0f;
        }
    }
}
