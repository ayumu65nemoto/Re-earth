using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backpageScript : MonoBehaviour
{
    public Button select1;
    public Button FirstSelectButton;
    public static int Bkey;
    // Start is called before the first frame update
    void Start()
    {
        FirstSelectButton.Select();
        Bkey = 0;
    }

    public void TappedButton2()
    {
        Bkey += 1;
    }

    public static int BackKey()
    {
        return Bkey;
    }

    public void Update()
    {
        Bkey = CanvasSelectScript.PointA();
    }
}