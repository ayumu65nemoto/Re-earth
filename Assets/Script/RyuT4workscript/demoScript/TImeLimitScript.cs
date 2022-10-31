using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImeLimitScript : MonoBehaviour
{

    public bool roop;
    public Image UIobj;
    public float countTime = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (roop)
            {
                UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            }
    }
}
