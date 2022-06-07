using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown1_2 : MonoBehaviour
{
    private float time = 30.00f;  //経過時間
    private float time2 = 5.0f;  //ゲームオーバー時の時間
    public int currentHp;
    public int maxHp;      //最大HP
    public Slider hpBar;   //HPバー
    public Text hpText;    //HPの数字
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
        //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;

        //スライダーの最大値を変更
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
        //スライダーの値をリアルタイムで変更
        hpBar.value = currentHp;

        //HPテキストの変更
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = 文字化

        if (currentHp <= 0)
        {
            gameOverText.text = "GAME OVER";
            // 経過時間をカウント
            time += Time.deltaTime;
            time2 -= Time.deltaTime;
            returnText.text = time2.ToString("F0") + "秒後タイトルに戻ります";

            // 3秒後に画面遷移（Titleへ移動）
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
