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

    public Text gameOverText; //ゲームオーバーの文字
    private float step_time; //経過時間

    // Start is called before the first frame update
    void Start()
    {   //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;

        //スライダーの最大値を変更
        hpBar.maxValue = maxHp;
    }

    // Update is called once per frame
    void Update()
    {   //スライダーの値をリアルタイムで変更
        hpBar.value = currentHp;

        //HPテキストの変更
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = 文字化

        if (currentHp <= 0)
        {
            gameOverText.enabled = true;
            // 経過時間をカウント
            step_time += Time.deltaTime;

            // 3秒後に画面遷移（Titleへ移動）
            if (step_time >= 3.0f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    //ダメージ
    public void Damage()
    {   //現在値から－10
        currentHp -= 5;
    }

    //ボスダメージ
    public void BossDamage()
    {
        currentHp -= 10;
    }
}
