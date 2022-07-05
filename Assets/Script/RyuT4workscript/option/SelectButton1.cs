using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton1 : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    void Start()
    {
        
    }
    // Start is called before the first frame update
    public void OnClickStartButton()
    {

        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel2.SetActive(false);
    }
}
