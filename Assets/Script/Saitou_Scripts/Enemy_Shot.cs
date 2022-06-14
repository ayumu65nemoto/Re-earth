using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;
    public float ballSpeed = 5.0f;


    void Start()
    {
        transform.LookAt(player.transform);
        StartCoroutine("BallShot");
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }



    IEnumerator BallShot()
    {
        while (true)
        {
            var shot = Instantiate(ball, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
            yield return new WaitForSeconds(4.3f);
        }
    }
}
