using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnTitleScript : MonoBehaviour
{
    public Button FirstSelectButton;


    void Start()
    {
        FirstSelectButton.Select();

        
    }
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
        CountDown.score = 0;
        ChangeScoreScript.rankscore = 0;
    }

}
