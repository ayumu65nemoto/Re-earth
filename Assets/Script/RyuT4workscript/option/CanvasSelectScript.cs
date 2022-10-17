using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSelectScript : MonoBehaviour
{
    public GameObject Panel0;
    public GameObject Panel1;
    public GameObject Panel2;
    public Button select1;
    public Button select2;
    public Button FirstSelectButton;
    public int changekey;

    // Start is called before the first frame update
    void Start()
    {
        Panel0.SetActive(true);
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        FirstSelectButton.Select();
        changekey = 0;
    }

    // Update is called once per frame

    public void TappedButton1()
    {
        changekey += 1;

        if(changekey == -1)
        {
            changekey = 2;
        }

        if(changekey == 3)
        {
            changekey = 0;
        }

        if(changekey == 0)
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
        }

        if(changekey == 1)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
        }

        if(changekey == 2)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
        }



    }

    public void TappedButton2()
    {
        changekey -= 1;

        if (changekey == -1)
        {
            changekey = 2;
        }

        if (changekey == 3)
        {
            changekey = 0;
        }

        if (changekey == 0)
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
        }

        if (changekey == 1)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
        }

        if (changekey == 2)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
        }
    }

}
