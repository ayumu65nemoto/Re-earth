using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText;
    int score;

    void Start()
    {
        score = CountDown.Getscore();

        ScoreText.text = string.Format("スコア：{0}", score);
    }
}
