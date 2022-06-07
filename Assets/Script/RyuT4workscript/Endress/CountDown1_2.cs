using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown1_2 : MonoBehaviour
{
    private float time = 30.00f;  //�o�ߎ���
    private float time2 = 5.0f;  //�Q�[���I�[�o�[���̎���
    public int currentHp;
    public int maxHp;      //�ő�HP
    public Slider hpBar;   //HP�o�[
    public Text hpText;    //HP�̐���
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public Text timerText;
    public Text timeUpText;
    public Text pleaseEnterText;
    public Text gameOverText;
    public Text returnText;

    void Start()
    {
        //�ő�HP��ݒ�
        maxHp = 100;
        //���ݒl���ő��
        currentHp = maxHp;

        //�X���C�_�[�̍ő�l��ύX
        hpBar.maxValue = maxHp;

        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Panel4.SetActive(!Panel4.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Panel3.SetActive(!Panel3.activeSelf);

            if (Panel3.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //�X���C�_�[�̒l�����A���^�C���ŕύX
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

        if (0 < time)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            Time.timeScale = 0f;
            timeUpText.text = "TIME UP";
            pleaseEnterText.text = "Please Enter";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Panel1.SetActive(false);
                Panel2.SetActive(true);
            }
        }

        //if (BOSS = 0)
        //{
        //Time.timeScale = 0f;
        //Panel1.SetActive(false);
        //Panel5.SetActive(true);
        //}
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //Panel5.SetActive(false);
        //Panel2.SetActive(true);
        //}
    }
}
