using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankingScoreScript : MonoBehaviour
{
    public int[] RankSc = new int[] { 0, 0, 0, 0, 0 };
    string[] ranking = { "Rank1", "Rank2", "Rank3", "Rank4", "Rank5" };

    public void Start()
    {
        int score = 0;
        score = CountDown.Getscore();

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
        }

    }
}
