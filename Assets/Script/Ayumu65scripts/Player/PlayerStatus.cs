using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private float time = 50.00f;  //経過時間
    private float time2 = 5.0f;  //ゲームオーバー時の時間

    public int currentHp;
    public int maxHp;
    const int MIN = 0;
    const int MAX = 100;

    //public Slider hpBar;
    public Text hpText;

    public Text gameOverText;
    public Text returnText;

    public Image HPbardemo1; //追加箇所

    // Start is called before the first frame update
    void Start()
    {   //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;

        //スライダーの最大値を変更
        //hpBar.maxValue = maxHp;
        HPbardemo1.fillAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {   //スライダーの値をリアルタイムで変更
        //hpBar.value = currentHp;

        //HPテキストの変更
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = 文字化

        if (currentHp <= 50) ;
        {
            CountDown.facechange = 4;
        }

        if (currentHp <= 0)
        {
            gameOverText.text = "GAME OVER";
            // 経過時間をカウント
            time += Time.deltaTime;
            time2 -= Time.deltaTime;
            returnText.text = time2.ToString("F0") + "秒後タイトルに戻ります";
            CountDown.facechange = 3;

            // 3秒後に画面遷移（Titleへ移動）
            if (time2 <= 0)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    //ダメージ
    public void Damage()
    {   //現在値から−10
        currentHp -= 3;
        HPbardemo1.fillAmount -= 3 / 100f;

        // 最大値を超えたら最大値を渡す
        currentHp = System.Math.Min(currentHp, MAX);
        // 最小値を下回ったら最小値を渡す
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //ボスダメージ
    public void BossDamage()
    {
        currentHp -= 7;
        HPbardemo1.fillAmount -= 7 / 100f;

        // 最大値を超えたら最大値を渡す
        currentHp = System.Math.Min(currentHp, MAX);
        // 最小値を下回ったら最小値を渡す
        currentHp = System.Math.Max(currentHp, MIN);
    }

    //回復
    public void Heal()
    {
        currentHp += 2;
        HPbardemo1.fillAmount += 2 / 100f;

        // 最大値を超えたら最大値を渡す
        currentHp = System.Math.Min(currentHp, MAX);
        // 最小値を下回ったら最小値を渡す
        currentHp = System.Math.Max(currentHp, MIN);
    }
}
