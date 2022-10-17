using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSettingScript : MonoBehaviour
{

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public Button select1;
    public Button select2;
    public Button FirstSelectButton;
    public int countkey;
    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        FirstSelectButton.Select();
        countkey = 0;
    }


    public void TappedButton1()
    {
        countkey +=1;
        if (countkey == 3)
        {
            countkey = 0;
        }

        if (countkey == -1)
        {
            countkey = 2;
        }

        if (countkey == 0)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
        }

        if (countkey == 1)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
        }

        if (countkey == 2)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
        }
    }

    public void TappedButton2()
    {
        countkey += -1;
        if (countkey == 3)
        {
            countkey = 0;
        }

        if (countkey == -1)
        {
            countkey = 2;
        }

        if (countkey == 0)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
        }

        if (countkey == 1)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
        }

        if (countkey == 2)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
        }
    }

}
