using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class modeScript1 : MonoBehaviour
{
    public float counttime;
    public bool startkey;
    public bool counter;
    public Text timerText;
    public GameObject black1;
    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 1f;
        counter = false;
        startkey = false;
        counttime = 3f;
        black1.SetActive(false);
    }

    private void Update()
    {
        if(counter == true)
        {
            counttime -= Time.deltaTime;
            black1.SetActive(true);
            timerText.text = counttime.ToString("F0");
            if (counttime < 0)
            {
                startkey = true;
            }
            if (startkey == true)
            {
                SceneManager.LoadScene("game1");
            }
        }



    }


    void OnClickStartButton()
    {
        counter = true;
    }




}
