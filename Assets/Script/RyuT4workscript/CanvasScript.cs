using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    private float timeres = 5.0f;
    public Text scoretext;
    public Text returnText;
    int score = 0;
    public GameObject Panel1;
    public GameObject Panel2;
    bool keyA;
    // Start is called before the first frame update
    void Start()
    {
        keyA = false;
        score = 0;
        Panel1.SetActive(true);
        Panel2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = CountDown.Getscore();
        scoretext.text = string.Format("スコア：{0}", score);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            keyA = true;
        }
        if(keyA)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            timeres -= Time.deltaTime;
            returnText.text = timeres.ToString("F0") + "秒後ランキングに移ります";
            if (timeres <= 0)
            {
                timeres = 5.0f;
                SceneManager.LoadScene("ranking");
            }
        }

    }
}
