using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

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
        
    }
}
