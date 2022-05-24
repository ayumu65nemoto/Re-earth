using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown2_2: MonoBehaviour
{
    private float time = 120.00f;
    public Text timerText;
    public Text timeUpText;

    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            timeUpText.text = "TIME UP";
        }
    }
}