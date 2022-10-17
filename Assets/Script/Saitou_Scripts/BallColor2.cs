using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color32(0, 255, 150, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
