using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeScoreScript : MonoBehaviour
{

    [SerializeField] private RankdeletetrueScript anotherScript;
    public Text Rank1;
    public Text Rank2;
    public Text Rank3;
    public Text Rank4;
    public Text Rank5;
    public static int rankscore;
    public Text demo;
    public int[] RankSc = new int[] { 0, 0, 0, 0, 0 };
    string[] ranking = { "Rank1", "Rank2", "Rank3", "Rank4", "Rank5" };
    public static int reset;
    public static int yestrue;
    public static int  change;
    public GameObject gamen1;
    public GameObject gamen2;

    public void Start()
    {
        change = 0;
        gamen1.SetActive(true);
        gamen2.SetActive(false);
        reset = 0;
        yestrue = 0;
        rankscore = CountDown.Getscore();
        demo.text = string.Format("前回スコア：{0}", rankscore);

        for (int i = 0; i < 5; i++)
        {
            RankSc[i] = PlayerPrefs.GetInt(ranking[i], 0);
        }

        for (int i = 0; i < 5; i++)
        {
            if(rankscore >= RankSc[i])
            {
                var change = RankSc[i];
                RankSc[i] = rankscore;
                rankscore = change;
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

    public void Update()
    {
        reset = RankdeleteScript.Getdelete();
        yestrue = RankdeletetrueScript.Getdeletetrue();
        if (reset == 1)
        {
            gamen1.SetActive(false);
            gamen2.SetActive(true);
        }

        if (yestrue == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                RankSc[i] = PlayerPrefs.GetInt(ranking[i], 0);
            }

            for (int i = 0; i < 5; i++)
            {
                if (RankSc[i] > 0)
                {
                    var change = RankSc[i];
                    RankSc[i] = 0;
                    change = 0;
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

            gamen1.SetActive(true);
            gamen2.SetActive(false);

            change = 1;
            reset = 0;
            yestrue = 0;

        }


    }

    public static int Gettruechange()
    {
        return change;
    }

    public static int Gettruereset()
    {
        return reset;
    }

    public static int Gettrueyes()
    {
        return yestrue;
    }
}
