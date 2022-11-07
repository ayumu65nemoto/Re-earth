using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePouseScript : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public Button select1;
    public Button select2;
    public Button select3;
    public Button select4;
    public Button FirstSelectButton;

    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(true);
        FirstSelectButton.Select();
    }

    // Update is called once per frame

    public void TappedButton1()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        Panel4.SetActive(false);
    }

    public void TappedButton2()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    public void TappedButton3()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    public void TappedButton4()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(true);
    }
}

