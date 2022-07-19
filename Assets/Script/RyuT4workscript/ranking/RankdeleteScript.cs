using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankdeleteScript : MonoBehaviour
{

    public static int delete;
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        delete = 1;
    }

    public static int Getdelete()
    {
        return delete;
    }
}
