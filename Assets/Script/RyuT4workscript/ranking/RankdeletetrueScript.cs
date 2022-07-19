using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankdeletetrueScript : MonoBehaviour
{
    public static int yes;
    public int chan;
    // Start is called before the first frame update

    public void start()
    {
        
        yes = 0;

    }
    public void pushbutton()
    {
        yes = 1;
    }

    public void Update()
    {
        chan = ChangeScoreScript.Gettruechange();
        if (chan == 1)
        {
            yes = 0;
        }
    }

    public static int Getdeletetrue()
    {
        return yes;
    }
}
