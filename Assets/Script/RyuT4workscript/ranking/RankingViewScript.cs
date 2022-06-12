using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingViewScript : MonoBehaviour
{

    public Text Rank1;
    public Text Rank2;
    public Text Rank3;
    public Text Rank4;
    public Text Rank5;

    public void RankOutput()
    {
        Rank1.text = string.Format("1位：{0}", PlayerPrefs.GetInt("Rank1"));
        Rank2.text = string.Format("2位：{0}", PlayerPrefs.GetInt("Rank2"));
        Rank3.text = string.Format("3位：{0}", PlayerPrefs.GetInt("Rank3"));
        Rank4.text = string.Format("4位：{0}", PlayerPrefs.GetInt("Rank4"));
        Rank5.text = string.Format("5位：{0}", PlayerPrefs.GetInt("Rank5"));
    }

}
