using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demoUIscript : MonoBehaviour
{
    public Image UIobj;
    public bool roop;
    public float countTime = 5.0f;
    public Text democount;
    public int demo1 = 5;
    // Update is called once per frame
    void Update()
    {
        if(demo1 > 0)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                demo1 -= 1;
                UIobj.fillAmount += 1;
                democount.text = string.Format("{0}", demo1);
            }
            if (roop)
            {
                UIobj.fillAmount -= 4.0f / countTime * Time.deltaTime;
            }
        }



    }

}
