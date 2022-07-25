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
    public int demo1 = 5;  //スキル回数
    public bool demoskill1;
    public bool demoskill2;

    public Image UIobj2;
    public float countTime2 = 5.0f;
    public Text democount2;
    public int demo2 = 5;  //スキル回数
    public float skillTime1;
    public float skillTime2;

    public Image UIobj3;
    public float countTime3 = 5.0f;
    public Text democount3;
    public int demo3 = 5;  //スキル回数
    public bool demoskill3;
    public float skillTime3;

    private void Start()
    {
        demoskill1 = true;
        demoskill2 = true;
        demoskill3 = true;
        skillTime1 = 0.0f;
        skillTime2 = 0.0f;
        skillTime3 = 0.0f;
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

        if (demoskill2 == true)
        {
            if (demo2 > 0)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    demo2 -= 1;
                    UIobj2.fillAmount += 1;
                    democount2.text = string.Format("{0}", demo2);
                    demoskill2 = false;
                }

            }

        }

        if (demoskill2 == false)
        {
            skillTime2 += Time.deltaTime;
            if (skillTime2 >= 5)
            {
                demoskill2 = true;
                skillTime2 = 0.0f;
            }

            if (roop)
            {
                UIobj2.fillAmount -= 1.0f / countTime2 * Time.deltaTime;
            }
        }

        if (demoskill3 == true)
        {
            if (demo3 > 0)
            {

                if (Input.GetKeyDown(KeyCode.C))
                {
                    demo3 -= 1;
                    UIobj3.fillAmount += 1;
                    democount3.text = string.Format("{0}", demo3);
                    demoskill3 = false;
                }

            }

        }

        if (demoskill3 == false)
        {
            skillTime3 += Time.deltaTime;
            if (skillTime3 >= 5)
            {
                demoskill3 = true;
                skillTime3 = 0.0f;
            }

            if (roop)
            {
                UIobj3.fillAmount -= 1.0f / countTime3 * Time.deltaTime;
            }
        }
    }

}
