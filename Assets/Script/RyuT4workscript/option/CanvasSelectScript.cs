using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSelectScript : MonoBehaviour
{
    public GameObject Panel0;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public Button select1;
    public Button select2;
    public Button FirstSelectButton;
    public int changekey;
    public static int key;
    public static int returnkey;

    // Start is called before the first frame update
    void Start()
    {
        Panel0.SetActive(true);
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        Panel6.SetActive(false);
        FirstSelectButton.Select();
        changekey = 0;
        key = 0;

    }

    public void Update()
    {
        if (1 == nextpageScript.NextKey())
        {
            changekey += 1;
            returnkey = 0;
        }

        if(1 == backpageScript.BackKey())
        {
            changekey -= 1;
            returnkey = 0;

        }

        changekey += key;

        if (changekey == -1)
        {
            changekey = 6;
        }

        if (changekey == 7)
        {
            changekey = 0;
        }

        if (changekey == 0)
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel6.SetActive(false);
        }

        if (changekey == 1)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
        }

        if (changekey == 2)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
        }

        if (changekey == 3)
        {
            Panel2.SetActive(false);
            Panel3.SetActive(true);
            Panel4.SetActive(false);
        }

        if (changekey == 4)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(true);
            Panel5.SetActive(false);
        }

        if (changekey == 5)
        {
            Panel4.SetActive(false);
            Panel5.SetActive(true);
            Panel6.SetActive(false);
        }

        if (changekey == 6)
        {
            Panel0.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(true);
        }

    }

    public static int PointA()
    {
        return returnkey;
    }

}
