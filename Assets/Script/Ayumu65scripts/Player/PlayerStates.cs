using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        //Å‘åHP‚ğİ’è
        maxHp = 100;
        //Œ»İ’l‚ğÅ‘å‚É
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
