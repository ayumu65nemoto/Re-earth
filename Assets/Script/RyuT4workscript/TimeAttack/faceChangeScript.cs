using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceChangeScript : MonoBehaviour
{
    public GameObject face1;  //�ʏ펞
    public GameObject face2;  //50��
    public GameObject face3;  //�Q�[���I�[�o�[
    public GameObject face4;  //�N���A
    public GameObject face5;  //�H�������
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
        //�N���A�̊�
        if (facekey == 1)
        {
            face1.SetActive(true);
            face2.SetActive(false);
            face3.SetActive(false);
            face4.SetActive(false);
            face5.SetActive(false);
        }

        //�Q�[���I�[�o�[�̊�
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
