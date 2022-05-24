using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    public Slider hpBar;
    public Text hpText;

    public Text gameOverText; //�Q�[���I�[�o�[�̕���
    private float step_time; //�o�ߎ���

    // Start is called before the first frame update
    void Start()
    {   //�ő�HP��ݒ�
        maxHp = 100;
        //���ݒl���ő��
        currentHp = maxHp;

        //�X���C�_�[�̍ő�l��ύX
        hpBar.maxValue = maxHp;
    }

    // Update is called once per frame
    void Update()
    {   //�X���C�_�[�̒l�����A���^�C���ŕύX
        hpBar.value = currentHp;

        //HP�e�L�X�g�̕ύX
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = ������

        if (currentHp <= 0)
        {
            gameOverText.enabled = true;
            // �o�ߎ��Ԃ��J�E���g
            step_time += Time.deltaTime;

            // 3�b��ɉ�ʑJ�ځiTitle�ֈړ��j
            if (step_time >= 3.0f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    //�_���[�W
    public void Damage()
    {   //���ݒl����|10
        currentHp -= 5;
    }

    //�{�X�_���[�W
    public void BossDamage()
    {
        currentHp -= 10;
    }
}
