using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_war : MonoBehaviour
{
    

    public float timeOut;
    private float timeElapsed;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timeElapsed += Time.deltaTime;

        //if (timeElapsed >= timeOut >= startTime)
        //{
            // Do anything
        //    startTime = 10.0f;
        //   timeElapsed = 20.0f;

            transform.position -= transform.forward;
        //}
    }
}