using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private float time = 50.00f;  //�o�ߎ���
    private float time2 = 5.0f;  //�Q�[���I�[�o�[���̎���
    private float changetime = 1.0f;

    public int currentHp;
    public int maxHp;
    const int MIN = 0;
    const int MAX = 100;

    //public Slider hpBar;
    public Text hpText;

    public Text gameOverText;
    public Text returnText;

    public Image HPbardemo1; //�ǉ��ӏ�
    public int damagekey = 0; //�_���[�W���󂯂��Ƃ�

    // Start is called before the first frame update
    void Start()
    {   //�ő�HP��ݒ�
        maxHp = 100;
        //���ݒl���ő��
        currentHp = maxHp;

        //�X���C�_�[�̍ő�l��ύX
        //hpBar.maxValue = maxHp;
        HPbardemo1.fillAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {   //�X���C�_�[�̒l�����A���^�C���ŕύX
        //hpBar.value = currentHp;

        //HP�e�L�X�g�̕ύX
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = ������

        if(currentHp >= 50)
        {
            CountDown.facechange = 1;
        }

        if (currentHp < 50)
        {
            CountDown.facechange = 2;
        }

        if (currentHp <= 0)
        {
            gameOverText.text = "GAME OVER";
            // �o�ߎ��Ԃ��J�E���g
            time += Time.deltaTime;
            time2 -= Time.deltaTime;
            returnText.text = time2.ToString("F0") + "�b��^�C�g���ɖ߂�܂�";
            CountDown.facechange = 3;

            // 3�b��ɉ�ʑJ�ځiTitle�ֈړ��j
            if (time2 <= 0)
            {
                SceneManager.LoadScene("Title");
            }
        }

        if(damagekey == 1)
        {
            changetime -= Time.deltaTime;
            CountDown.facechange = 5;
            if (changetime < 0)
            {
                CountDown.facechange = 1;
                damagekey = 0;
                changetime = 1.0f;
            }
        }
    }

    //�_���[�W
    public void Damage()
    {   //���ݒl����|10

        currentHp -= 3;
        HPbardemo1.fillAmount -= 3 / 100f;
        damagekey = 1;


        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //�{�X�_���[�W
    public void BossDamage()
    {
        currentHp -= 7;
        HPbardemo1.fillAmount -= 7 / 100f;
        damagekey = 1;

        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //��
    public void Heal()
    {
        currentHp += 2;
        HPbardemo1.fillAmount += 2 / 100f;

        // �ő�l�𒴂�����ő�l��n��
        currentHp = System.Math.Min(currentHp, MAX);
        // �ŏ��l�����������ŏ��l��n��
        currentHp = System.Math.Max(currentHp, MIN);
    }
}
