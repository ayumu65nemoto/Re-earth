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
    public bool demoskill1;
    public bool demoskill2;

    public Image UIobj2;
    public float countTime2 = 5.0f;
    public Text democount2;
    public int demo2 = 5;
    public float skillTime1;


    private void Start()
    {
        demoskill1 = true;
        skillTime1 = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (demoskill1 == true)
        {
            if (demo1 > 0)
            {

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    demo1 -= 1;
                    UIobj.fillAmount += 1;
                    democount.text = string.Format("{0}", demo1);
                    demoskill1 = false;
                }

            }

        }

        if(demoskill1 == false)
        {
            skillTime1 += Time.deltaTime;
            if(skillTime1 >= 5)
            {
                demoskill1 = true;
                skillTime1 = 0.0f;
            }

            if (roop)
            {
                UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            }
        }

        if (demo2 > 0)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                demo2 -= 1;
                UIobj2.fillAmount += 1;
                democount2.text = string.Format("{0}", demo2);
            }
            if (roop)
            {
                UIobj2.fillAmount -= 4.0f / countTime2 * Time.deltaTime;
            }
        }

    }

}
