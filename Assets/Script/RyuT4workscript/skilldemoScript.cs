using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilldemoScript : MonoBehaviour
{
    public Image UIobj;
    public bool loop;
    public float countTime = 5.0f;
    public Text demotext;
    public int demo = 5;
    // Update is called once per frame
    void Update()
    {
        if(demo > 0)
        {
            if (loop)
            {
                UIobj.fillAmount -= 4.0f / countTime * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                demo -= 1;
                demotext.text = string.Format("{0}", demo);
                UIobj.fillAmount = 1;

            }
        }

    }

}
