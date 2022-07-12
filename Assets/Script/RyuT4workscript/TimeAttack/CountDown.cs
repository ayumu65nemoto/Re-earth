using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    private float time = 50.00f;  //�o�ߎ���
    private float time2 = 5.0f;  //�Q�[���I�[�o�[���̎���
    public int currentHp;
    public int maxHp;      //�ő�HP
    public Slider hpBar;   //HP�o�[
    public Text hpText;    //HP�̐���
    public int mathscore;
    public static int score;  //�X�R�A�i�[�ϐ��i�V�[�����L�j
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public Text timerText;
    public Text timeUpText;
    public Text pleaseEnterText;
    public Text gameOverText;
    public Text returnText;
    public Text scoretext;
    public int deadcount;
    public int deadcount2;
    public int CLEAR;

    private void OnCollisionEnter(Collision collision)
    {
        scoretext.text = string.Format("�X�R�A�F{0}", score);

        GetComponent<ParticleSystem>().Play();
    }

    void Start()
    {
        CLEAR = 0;
        deadcount = 0;
        mathscore = 0;
        mathscore = 30000;
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
        Panel5.SetActive(false);
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

            if(Panel3.activeSelf)
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
        ////�X���C�_�[�̒l�����A���^�C���ŕύX
        //hpBar.value = currentHp;

        ////HP�e�L�X�g�̕ύX
        //hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = ������

        //if (currentHp <= 0)
        //{
        //    gameOverText.text = "GAME OVER";
        //    // �o�ߎ��Ԃ��J�E���g
        //    time += Time.deltaTime;
        //    time2 -= Time.deltaTime;
        //    returnText.text = time2.ToString("F0") + "�b��^�C�g���ɖ߂�܂�";

        //    // 3�b��ɉ�ʑJ�ځiTitle�ֈړ��j
        //    if ( time2 <= 0)
        //    {
        //        SceneManager.LoadScene("Title");
        //    }
        //}

        if (0 < time)
        {
            mathscore -= 1;
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            deadcount = EnemyMove.GetdeadEnemy();
            deadcount2 = EnemyMove2.GetdeadEnemy2();
            score = (deadcount+ deadcount2) * mathscore;
            scoretext.text = string.Format("�X�R�A�F{0}", score);
            Time.timeScale = 0.001f;
            timeUpText.text = "TIME UP";
            pleaseEnterText.text = "Please Enter";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Panel1.SetActive(false);
                Panel2.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Title");
            }
        }


        CLEAR = BossMove.GetdeadEnemyclear();

        if(CLEAR == 1)
        {
            Time.timeScale = 0.001f;
            Panel1.SetActive(false);
            Panel5.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Panel5.SetActive(false);
                Panel2.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Title");
            }
        }

    }


    public static int Getscore()
    {
        return score;
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

