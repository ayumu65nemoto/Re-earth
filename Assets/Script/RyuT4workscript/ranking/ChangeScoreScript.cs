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
    public int[] RankSc = { };

    public void Start()
    {
        score = CountDown.Getscore();
        demo.text = string.Format("�X�R�A�F{0}", score);

        for (int i = 0; i < 5; i++)
        {
            if(score >= RankSc[i])
            {
                int change = RankSc[i];
                RankSc[i] = score;
                score = change;
            }
        }

    }

    public void RankOutput()
    {
        Rank1.text = string.Format("1�ʁF{0}", RankSc[0]);
        Rank2.text = string.Format("2�ʁF{0}", RankSc[1]);
        Rank3.text = string.Format("3�ʁF{0}", RankSc[2]);
        Rank4.text = string.Format("4�ʁF{0}", RankSc[3]);
        Rank5.text = string.Format("5�ʁF{0}", RankSc[4]);
    }
}
