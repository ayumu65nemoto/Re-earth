using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceChangeScript : MonoBehaviour
{
    public GameObject face1;  //通常時
    public GameObject face2;  //50％
    public GameObject face3;  //ゲームオーバー
    public GameObject face4;  //クリア
    public GameObject face5;  //食らった時
    public int facekey;

    // Start is called before the first frame update
    void Start()
    {
        face1.SetActive(true);
        face2.SetActive(false);
        face3.SetActive(false);
        face4.SetActive(false);
        face5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        facekey = CountDown.Facechange1();
        //クリアの顔
        if (facekey == 1)
        {
            face1.SetActive(true);
            face2.SetActive(false);
            face3.SetActive(false);
            face4.SetActive(false);
            face5.SetActive(false);
        }

        //ゲームオーバーの顔
        if(facekey == 2)
        {
            face1.SetActive(false);
            face2.SetActive(true);
            face3.SetActive(false);
            face4.SetActive(false);
            face5.SetActive(false);
        }

        if (facekey == 3)
        {
            face1.SetActive(false);
            face2.SetActive(false);
            face3.SetActive(true);
            face4.SetActive(false);
            face5.SetActive(false);
        }

        if (facekey == 4)
        {
            face1.SetActive(false);
            face2.SetActive(false);
            face3.SetActive(false);
            face4.SetActive(true);
            face5.SetActive(false);
        }

        if(facekey == 5)
        {
            face1.SetActive(false);
            face2.SetActive(false);
            face3.SetActive(false);
            face4.SetActive(false);
            face5.SetActive(true);
        }

    }


}
