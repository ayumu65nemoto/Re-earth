using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextpageScript : MonoBehaviour
{
    public Button select1;
    public Button FirstSelectButton;
    public static int Akey;
    // Start is called before the first frame update
    void Start()
    {
        FirstSelectButton.Select();
        Akey = 0;
    }

    public void TappedButton1()
    {
        Akey += 1;
    }

    public static int NextKey()
    {
        return Akey;
    }

    public void Update()
    {
        Akey = CanvasSelectScript.PointA();
    }
}
