using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    const int MIN = 0;
    const int MAX = 100;

    // Start is called before the first frame update
    void Start()
    {
        //�ő�HP��ݒ�
        maxHp = 100;
        //���ݒl���ő��
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }
}
