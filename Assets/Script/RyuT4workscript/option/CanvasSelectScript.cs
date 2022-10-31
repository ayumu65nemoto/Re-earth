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
    public GameObject Panel7;
    public GameObject Panel8;
    public GameObject Panel9;
    public GameObject Panel10;
    public GameObject Panel11;
    public GameObject Panel12;
    public GameObject Panel13;
    public GameObject Panel14;
    public GameObject Panel15;
    public GameObject Panel16;
    public GameObject Panel17;
    public GameObject Panel18;
    public GameObject Panel19;
    public GameObject Panel20;
    public GameObject Panel21;
    public GameObject Panel22;
    public GameObject Panel23;
    public GameObject Panel24;
    public GameObject Panel25;
    public GameObject Panel26;
    public GameObject Panel27;
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
        Panel7.SetActive(false);
        Panel8.SetActive(false);
        Panel9.SetActive(false);
        Panel10.SetActive(false);
        Panel11.SetActive(false);
        Panel12.SetActive(false);
        Panel13.SetActive(false);
        Panel14.SetActive(false);
        Panel15.SetActive(false);
        Panel16.SetActive(false);
        Panel17.SetActive(false);
        Panel18.SetActive(false);
        Panel19.SetActive(false);
        Panel20.SetActive(false);
        Panel21.SetActive(false);
        Panel22.SetActive(false);
        Panel23.SetActive(false);
        Panel24.SetActive(false);
        Panel25.SetActive(false);
        Panel26.SetActive(false);
        Panel27.SetActive(false);
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
            changekey = 22;
        }

        if (changekey == 23)
        {
            changekey = 0;
        }

        if (changekey == 0)
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel22.SetActive(false);
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
            Panel5.SetActive(false);
            Panel6.SetActive(true);
            Panel7.SetActive(false);
        }

        if (changekey == 7)
        {
            Panel6.SetActive(false);
            Panel7.SetActive(true);
            Panel8.SetActive(false);
        }

        if (changekey == 8)
        {
            Panel7.SetActive(false);
            Panel8.SetActive(true);
            Panel9.SetActive(false);
        }

        if (changekey == 9)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(true);
            Panel10.SetActive(false);
        }

        if (changekey == 10)
        {
            Panel9.SetActive(false);
            Panel10.SetActive(true);
            Panel11.SetActive(false);
        }

        if (changekey == 11)
        {
            Panel10.SetActive(false);
            Panel11.SetActive(true);
            Panel12.SetActive(false);
        }

        if (changekey == 12)
        {
            Panel11.SetActive(false);
            Panel12.SetActive(true);
            Panel13.SetActive(false);
        }

        if (changekey == 13)
        {
            Panel12.SetActive(false);
            Panel13.SetActive(true);
            Panel14.SetActive(false);
        }

        if (changekey == 14)
        {
            Panel13.SetActive(false);
            Panel14.SetActive(true);
            Panel15.SetActive(false);
        }

        if (changekey == 15)
        {
            Panel14.SetActive(false);
            Panel15.SetActive(true);
            Panel16.SetActive(false);
        }

        if (changekey == 16)
        {
            Panel15.SetActive(false);
            Panel16.SetActive(true);
            Panel17.SetActive(false);
        }

        if (changekey == 17)
        {
            Panel16.SetActive(false);
            Panel17.SetActive(true);
            Panel18.SetActive(false);
        }

        if (changekey == 18)
        {
            Panel17.SetActive(false);
            Panel18.SetActive(true);
            Panel19.SetActive(false);
        }

        if (changekey == 19)
        {
            Panel18.SetActive(false);
            Panel19.SetActive(true);
            Panel20.SetActive(false);
        }

        if (changekey == 20)
        {
            Panel19.SetActive(false);
            Panel20.SetActive(true);
            Panel21.SetActive(false);
        }

        if (changekey == 21)
        {
            Panel20.SetActive(false);
            Panel21.SetActive(true);
            Panel22.SetActive(false);
        }

        if (changekey == 22)
        {
            Panel21.SetActive(false);
            Panel22.SetActive(true);
            Panel0.SetActive(false);
        }

        /*if (changekey == 22)
        {
            Panel21.SetActive(false);
            Panel22.SetActive(true);
            Panel23.SetActive(false);
        }

        if (changekey == 23)
        {
            Panel22.SetActive(false);
            Panel23.SetActive(true);
            Panel24.SetActive(false);
        }

        if (changekey == 24)
        {
            Panel23.SetActive(false);
            Panel24.SetActive(true);
            Panel25.SetActive(false);
        }

        if (changekey == 25)
        {
            Panel24.SetActive(false);
            Panel25.SetActive(true);
            Panel26.SetActive(false);
        }

        if (changekey == 26)
        {
            Panel25.SetActive(false);
            Panel26.SetActive(true);
            Panel27.SetActive(false);
        }

        if (changekey == 27)
        {
            Panel26.SetActive(false);
            Panel27.SetActive(true);
            Panel0.SetActive(false);
        }*/

    }

    public static int PointA()
    {
        return returnkey;
    }

}
