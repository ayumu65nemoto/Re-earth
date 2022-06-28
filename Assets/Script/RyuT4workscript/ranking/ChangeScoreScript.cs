using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeScoreScript : MonoBehaviour
{
    public Text Rank1;
    public Text Rank2;
    public Text Rank3;
    public Text Rank4;
    public Text Rank5;
    int score;
    public Text demo;
    public int[] RankSc = new int[] { 0, 0, 0, 0, 0 };
    string[] ranking = { "Rank1", "Rank2", "Rank3", "Rank4", "Rank5" };

    public void Start()
    {
        score = CountDown.Getscore();
        demo.text = string.Format("前回スコア：{0}", score);

        for (int i = 0; i < 5; i++)
        {
            RankSc[i] = PlayerPrefs.GetInt(ranking[i], 0);
        }

        for (int i = 0; i < 5; i++)
        {
            if(score >= RankSc[i])
            {
                var change = RankSc[i];
                RankSc[i] = score;
                score = change;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(ranking[i], RankSc[i]);
            PlayerPrefs.Save();
        }

        Rank1.text = string.Format("1位：{0}", PlayerPrefs.GetInt("Rank1"));
        Rank2.text = string.Format("2位：{0}", PlayerPrefs.GetInt("Rank2"));
        Rank3.text = string.Format("3位：{0}", PlayerPrefs.GetInt("Rank3"));
        Rank4.text = string.Format("4位：{0}", PlayerPrefs.GetInt("Rank4"));
        Rank5.text = string.Format("5位：{0}", PlayerPrefs.GetInt("Rank5"));
    }

}
