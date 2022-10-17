using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private float time = 50.00f;  //�o�ߎ���
    private float time2 = 5.0f;  //�Q�[���I�[�o�[���̎���

    public int currentHp;
    public int maxHp;
    const int MIN = 0;
    const int MAX = 100;

    public Slider hpBar;
    public Text hpText;

    public Text gameOverText;
    public Text returnText;

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
            gameOverText.text = "GAME OVER";
            // �o�ߎ��Ԃ��J�E���g
            time += Time.deltaTime;
            time2 -= Time.deltaTime;
            returnText.text = time2.ToString("F0") + "�b��^�C�g���ɖ߂�܂�";

            // 3�b��ɉ�ʑJ�ځiTitle�ֈړ��j
            if (time2 <= 0)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    //�_���[�W
    public void Damage()
    {   //���ݒl����|10
        currentHp -= 3;
        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //�{�X�_���[�W
    public void BossDamage()
    {
        currentHp -= 7;
        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //��
    public void Heal()
    {
        currentHp += 2;
        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }
}
